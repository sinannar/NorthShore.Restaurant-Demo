import { Component, ViewChild, Injector, Output, Input, OnInit, EventEmitter, ElementRef } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { RestaurantServiceProxy, ShowMenuDto, AddFoodToMenuDto, ShowFoodDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/app-component-base';
import { Observable, forkJoin } from 'rxjs';

@Component({
    selector: 'edit-menu',
    templateUrl: './edit-menu.component.html',
})
export class EditMenuComponent extends AppComponentBase implements OnInit {
    @ViewChild('editMenuModal') modal: ModalDirective;
    @ViewChild('modalContent') modalContent: ElementRef;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    foodsInMenu: ShowFoodDto[];
    foodsNotInMenu: ShowFoodDto[];

    _selectedFood: ShowFoodDto;
    set selectedFood(value: ShowFoodDto) {
        this._selectedFood = value;
        this.setNewMapping(value);
    }
    get selectedFood(): ShowFoodDto {
        return this._selectedFood;
    }

    setNewMapping(food: ShowFoodDto) {
        var request = new AddFoodToMenuDto();
        request.menuId = this.selectedMenu.id;
        request.foodIds = [food.id];
        this._restaurantService.addFoodToMenu(request).subscribe(() => {
            this.intializeEditMenu();
            this.modalSave.emit(null);
        });
    }

    deleteFoodMapping(food: ShowFoodDto) {
        this.message.confirm(
            "Delete food '" + food.name + "' from menu '"+this.selectedMenu.name+"'?",
            (result: boolean) => {
                if (result) {
                    this._restaurantService.removeFoodFromMenu(this.selectedMenu.id, food.id).subscribe(() => {
                        this.intializeEditMenu();
                        this.modalSave.emit(null);
                    });
                }
            }
        );
    }

    _selectedMenu: ShowMenuDto;
    @Input() set selectedMenu(value: ShowMenuDto) {
        this._selectedMenu = value;
    }
    get selectedMenu(): ShowMenuDto {
        return this._selectedMenu;
    }

    ngOnInit() {
        this.intializeEditMenu();
    }

    intializeEditMenu() {
        if (this.selectedMenu) {
            var request = forkJoin(
                this._restaurantService.listFoodsInMenu(this.selectedMenu.id),
                this._restaurantService.listFoodsNotInMenu(this.selectedMenu.id)
            );

            request.subscribe(result => {
                this.foodsInMenu = result[0],
                    this.foodsNotInMenu = result[1]
            });
        }
    }

    constructor(
        injector: Injector,
        private _restaurantService: RestaurantServiceProxy
    ) {
        super(injector);
    }
    active: boolean = false;
    saving: boolean = false;

    show() {
        this.active = true;
        this.modal.show();
    }

    onShown(): void {
        $.AdminBSB.input.activate($(this.modalContent.nativeElement));
        this.intializeEditMenu();
    }

    close(): void {
        this.active = false;
        this.modal.hide();
    }
}
