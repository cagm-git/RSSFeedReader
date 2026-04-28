import { test, expect } from '../support/fixtures';

test.describe('RSS Reader E2E', () => {
  test('should navigate to the home page', async ({ page }) => {
    await page.goto('/');
    
    // Check for some text or element that should be present on the home page
    // await expect(page).toHaveTitle(/RSS Feed Reader/);
  });
});
