import { test, expect } from '@playwright/test';

test.describe('Subscriptions E2E', () => {
  test.beforeEach(async ({ page }) => {
    await page.goto('/');
  });

  test('[P0] should successfully add a subscription', async ({ page }) => {
    const feedUrl = 'https://valid-feed.com/rss.xml';
    
    await page.getByLabel('Feed URL').fill(feedUrl);
    await page.getByRole('button', { name: 'Add Subscription' }).click();

    await expect(page.getByText(feedUrl)).toBeVisible();
    await expect(page.getByLabel('Feed URL')).toHaveValue('');
  });

  test('[P1] should show error for empty URL', async ({ page }) => {
    await page.getByRole('button', { name: 'Add Subscription' }).click();

    await expect(page.getByRole('alert')).toHaveText('Please enter a feed URL.');
  });

  test('[P1] should show error for duplicate URL', async ({ page }) => {
    const feedUrl = 'https://already-added.com/rss.xml';

    // Add first time
    await page.getByLabel('Feed URL').fill(feedUrl);
    await page.getByRole('button', { name: 'Add Subscription' }).click();
    await expect(page.getByText(feedUrl)).toBeVisible();

    // Try adding again
    await page.getByLabel('Feed URL').fill(feedUrl);
    await page.getByRole('button', { name: 'Add Subscription' }).click();

    await expect(page.getByRole('alert')).toHaveText('This feed URL has already been added.');
  });
});