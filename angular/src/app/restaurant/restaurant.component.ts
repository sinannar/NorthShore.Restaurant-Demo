import { Component, Injector, AfterViewInit, ViewChild } from '@angular/core';
import { AppComponentBase } from '@shared/app-component-base';
import { appModuleAnimation } from '@shared/animations/routerTransition';

@Component({
    templateUrl: './restaurant.component.html',
    animations: [appModuleAnimation()],
})
export class RestaurantComponent extends AppComponentBase {


    constructor(
        injector: Injector,
    ) {
        super(injector);
    }
}
