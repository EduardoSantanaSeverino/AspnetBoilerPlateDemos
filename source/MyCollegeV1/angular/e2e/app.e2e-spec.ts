import { MyCollegeV1TemplatePage } from './app.po';

describe('MyCollegeV1 App', function() {
  let page: MyCollegeV1TemplatePage;

  beforeEach(() => {
    page = new MyCollegeV1TemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
