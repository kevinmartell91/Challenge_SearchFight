
# Search Fight Challenge
### Usage


```sh
$ Cignium.SearchFight.exe .net java
```

### Expected Result

    .net: Google: 4450000000 Bing Search: 12354420
    java: Google: 966000000 Bing Search: 94381485
    Google winner: .net
    Bing winner: java
    Total winner: .net
    
### Update the App.config file
To test the SerachFight do not forget to update :

    Cignium.SearchFight.exe.config
This is the secction to update.
 ```{r, warning=FALSE}
<?xml version="1.0" encoding="UTF-8" ?>
<configuration>
  <appSettings>
    <!-- Google Search Engine Settings -->
    <add key="Google.BaseUrl" value="https://www.googleapis.com/customsearch/v1?key={ApiKey}&amp;cx={Context}&amp;q={Query}" />
    <add key="Google.ApiKey" value="YOUR_API_KEY_GOES_HERE" />
    <add key="Google.Cx" value="YOUR_CX_GOES_HERE" />
    <!-- Bing Search Engine Settings -->
    <add key="Bing.UriBase" value="https://api.cognitive.microsoft.com/bing/v7.0/search?q={Query}" />
    <add key="Bing.AccessKey" value="YOUR_ACCESS_KEY_GOES_HERE" />
  </appSettings>
</configuration>    
```   
