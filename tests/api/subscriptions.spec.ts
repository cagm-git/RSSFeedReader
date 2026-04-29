import { test, expect } from '@playwright/test';
import { apiRequest } from '@playwright-utils/api';

test.describe('Subscriptions API', () => {
  test('[P0] should return all subscriptions', async ({ request }) => {
    const response = await apiRequest(request, 'GET', '/api/subscriptions');
    expect(response.status()).toBe(200);
    const body = await response.json();
    expect(Array.isArray(body)).toBe(true);
  });

  test('[P0] should add a new subscription', async ({ request }) => {
    const feedUrl = `https://example.com/feed-${Date.now()}.xml`;
    const response = await apiRequest(request, 'POST', '/api/subscriptions', {
      data: { url: feedUrl }
    });
    expect(response.status()).toBe(201);
    const body = await response.json();
    expect(body.url).toBe(feedUrl);
  });

  test('[P1] should return 400 for empty URL', async ({ request }) => {
    const response = await apiRequest(request, 'POST', '/api/subscriptions', {
      data: { url: '' }
    });
    expect(response.status()).toBe(400);
    const body = await response.json();
    expect(body.error).toBe('A non-empty URL is required.');
  });

  test('[P1] should return 409 for duplicate URL', async ({ request }) => {
    const feedUrl = 'https://duplicate.com/feed.xml';
    // First add
    await apiRequest(request, 'POST', '/api/subscriptions', {
      data: { url: feedUrl }
    });
    // Second add
    const response = await apiRequest(request, 'POST', '/api/subscriptions', {
      data: { url: feedUrl }
    });
    expect(response.status()).toBe(409);
    const body = await response.json();
    expect(body.error).toBe('Subscription already exists or URL is invalid.');
  });
});