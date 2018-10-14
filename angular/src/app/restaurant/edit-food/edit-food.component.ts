import { Component, ViewChild, Injector, Output, Input, EventEmitter, ElementRef } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap';
import { RestaurantServiceProxy, EditFoodDto, ShowFoodDto } from '@shared/service-proxies/service-proxies';
import { AppComponentBase } from '@shared/app-component-base';

@Component({
    selector: 'edit-food',
    templateUrl: './edit-food.component.html',
})
export class EditFoodComponent extends AppComponentBase {
    @ViewChild('editFoodModal') modal: ModalDirective;
    @ViewChild('modalContent') modalContent: ElementRef;

    @Output() modalSave: EventEmitter<any> = new EventEmitter<any>();

    private _selectedFood: ShowFoodDto;
    @Input() set selectedFood(value: ShowFoodDto) {
        this._selectedFood = value;
        if (value && !this.food) {
            this.food = new ShowFoodDto({
                id: value.id,
                calorie: value.calorie,
                name: value.name,
                isGlutenFree: value.isGlutenFree,
                isDairyFree: value.isDairyFree,
                isNutFree: value.isNutFree,
                price: value.price,
            });
        }
    }
    get selectedFood(): ShowFoodDto { return this._selectedFood; }

    active: boolean = false;
    saving: boolean = false;
    food: EditFoodDto;

    constructor(
        injector: Injector,
        private _restaurantService: RestaurantServiceProxy
    ) {
        super(injector);
    }

    show() {
        this.active = true;
        this.modal.show();
    }

    onShown(): void {
        $.AdminBSB.input.activate($(this.modalContent.nativeElement));
    }

    save() {
        this.saving = true;
        this._restaurantService.editFood(this.food)
            .finally(() => { this.saving = false; })
            .subscribe(() => {
                this.notify.info(this.l('SavedSuccessfully'));
                this.modalSave.emit(null);
                this.food = null;
                this.close();
            });
    }

    close(): void {
        this.active = false;
        this.modal.hide();
    }
}
