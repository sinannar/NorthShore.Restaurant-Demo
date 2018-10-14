import { Component, ViewChild, Injector, Output, EventEmitter, ElementRef } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { RestaurantServiceProxy, CreateMenuDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/app-component-base';

@Component({
    selector: 'create-menu',
    templateUrl: './create-menu.component.html',
})
export class CreateMenuComponent extends AppComponentBase {
    @ViewChild('createMenuModal') modal: ModalDirective;
    @ViewChild('modalContent') modalContent: ElementRef;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active: boolean = false;
    saving: boolean = false;
    menu: CreateMenuDto = null;

    constructor(
        injector: Injector,
        private _restaurantService: RestaurantServiceProxy
    ) {
        super(injector);
    }

    show() {
        this.active = true;
        this.modal.show();
        this.menu = new CreateMenuDto();
    }

    onShown(): void {
        $.AdminBSB.input.activate($(this.modalContent.nativeElement));
    }

    save() {
        this.saving = true;
        this._restaurantService.createMenu(this.menu)
            .finally(() => { this.saving = false; })
            .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.modalSave.emit(null);
                this.close();
            });
    }

    close(): void {
        this.active = false;
        this.modal.hide();
    }
}
