import { Component, ViewChild, Injector, Output, EventEmitter, ElementRef } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { RestaurantServiceProxy, CreateFoodDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/app-component-base';

@Component({
    selector: 'create-food',
    templateUrl: './create-food.component.html',
})
export class CreateFoodComponent extends AppComponentBase {
    @ViewChild('createFoodModal') modal: ModalDirective;
    @ViewChild('modalContent') modalContent: ElementRef;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    active: boolean = false;
    saving: boolean = false;
    food: CreateFoodDto = null;

    constructor(
        injector: Injector,
        private _restaurantService: RestaurantServiceProxy
    ) {
        super(injector);
    }

    show() {
        this.active = true;
        this.modal.show();
        this.food = new CreateFoodDto();
    }

    onShown(): void {
        $.AdminBSB.input.activate($(this.modalContent.nativeElement));
    }

    save() {
        this.saving = true;
        this._restaurantService.createFood(this.food)
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
