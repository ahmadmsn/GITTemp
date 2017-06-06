import { EmployeeSamplePage } from './app.po';

describe('employee-sample App', () => {
  let page: EmployeeSamplePage;

  beforeEach(() => {
    page = new EmployeeSamplePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
