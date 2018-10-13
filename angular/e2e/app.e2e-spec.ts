import { RestaurantTemplatePage } from './app.po';

describe('Restaurant App', function() {
  let page: RestaurantTemplatePage;

  beforeEach(() => {
    page = new RestaurantTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
