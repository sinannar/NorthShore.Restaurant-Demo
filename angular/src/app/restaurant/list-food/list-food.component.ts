import { Component, Injector, AfterViewInit, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';
import { RestaurantServiceProxy, ShowFoodDto } from '@shared/service-proxies/service-proxies';

import { CreateFoodComponent } from 'app/restaurant/create-food/create-food.component';
import { EditFoodComponent } from 'app/restaurant/edit-food/edit-food.component';

@Component({
    selector: 'list-food',
    templateUrl: './list-food.component.html',
    animations: [appModuleAnimation()],
})
export class ListFoodComponent extends AppComponentBase {

    @ViewChild('createFoodModal') createFoodModal: CreateFoodComponent;
    @ViewChild('editFoodModal') editFoodModal: EditFoodComponent;

    foods: ShowFoodDto[];
    selectedFood:ShowFoodDto;
    constructor(
        injector: Injector,
        private _restaurantService: RestaurantServiceProxy,
    ) {
        super(injector);
        this.list();
    }

    list() {
        this._restaurantService.listFoods().subscribe(result => {
            this.foods = result;
        });
    }

    createFood() {
        this.createFoodModal.show();
    }

    editFood(food: ShowFoodDto) {
        this.selectedFood = food;
        this.editFoodModal.show();
    }

    deleteFood(food: ShowFoodDto) {
        this._restaurantService.deleteFood(food.id).subscribe(() => {
            this.list();
        })
    }

    refresh($event:any) {
        this.list();
    }

}
