import { Component, Injector, AfterViewInit, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { RestaurantServiceProxy, ShowMenuDto } from '@shared/service-proxies/service-proxies';

import { CreateMenuComponent } from 'app/restaurant/create-menu/create-menu.component';
import { EditMenuComponent} from '@app/restaurant/edit-menu/edit-menu.component';

@Component({
    selector: 'list-menu',
    templateUrl: './list-menu.component.html',
    animations: [appModuleAnimation()],
})
export class ListMenuComponent extends AppComponentBase {

    @ViewChild('createMenuModal') createMenuModal: CreateMenuComponent;
    @ViewChild('editMenuModal') editMenuModal: EditMenuComponent;

    menus: ShowMenuDto[];
    selectedMenu:ShowMenuDto;
    constructor(
        injector: Injector,
        private _restaurantService: RestaurantServiceProxy,
    ) {
        super(injector);
        this.list();
    }

    list() {
        this._restaurantService.listMenus().subscribe(result => {
            this.menus = result;
        });
    }

    createMenu() {
        this.createMenuModal.show();
    }

    editMenu(menu: ShowMenuDto) {
        this.selectedMenu = menu;
        this.editMenuModal.show();
    }

    deleteMenu(menu: ShowMenuDto) {
        this.message.confirm(
            "Delete food '" + menu.name + "'?",
            (result: boolean) => {
                if (result) {
                    this._restaurantService.deleteMenu(menu.id).subscribe(() => {
                        this.list();
                    })
                }
            }
        );
    }

    refresh($event:any) {
        this.list();
    }

}
