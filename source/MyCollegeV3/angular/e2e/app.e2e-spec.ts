import { MyCollegeV2TemplatePage } from './app.po';

describe('MyCollegeV2 App', function() {
  let page: MyCollegeV2TemplatePage;

  beforeEach(() => {
    page = new MyCollegeV2TemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
