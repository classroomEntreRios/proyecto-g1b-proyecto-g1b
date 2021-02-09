import { Viajar365TemplatePage } from './app.po';

describe('Viajar365 App', function() {
  let page: Viajar365TemplatePage;

  beforeEach(() => {
    page = new Viajar365TemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
