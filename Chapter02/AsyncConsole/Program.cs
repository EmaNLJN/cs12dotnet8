// See https://aka.ms/new-console-template for more information
HttpClient client = new();

HttpResponseMessage response =
  await client.GetAsync("http://www.google.com");

WriteLine("Google's home page has {0:N0} bytes.",
  response.Content.Headers.ContentLength
);
