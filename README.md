# url-shortener

* Docker shared image: docker pull ruyfrancisco/api

## Api methods
1. api/UrlShortener/Shorten
    * Http verb: Post
    * Param: 
    `{
      "url": "<value>"
    }` => original url
    * Return:
    `{
      "ShortenedUrl": "",
      "OriginalUrl": ""
    }`
    
2. api/UrlShortener/RedirectToOriginalUrl
    * Http verb: Post
    * Param: 
    `"value"` => shortened url
    * Return: Redirect to the original url
