# SeleniumFeedbackRadar

> Celem aplikacji jest przetestowanie funkcjonalności w serwisie FeedbackRadar

## Technologie
* C# wraz z Selenium

## Przeprowadzone testy

* Testowanie logowania
* Testowanie nawigacji
* Testowanie dodawania tłumaczenia

## Przykład kodu

*Wykorzystanie placeholdera*
```csharp
[Test]
  public void Login()
  {
      driver.Navigate().GoToUrl("https://feedbackradar-dev.azurewebsites.net/beheer/");

      InputByClass((ChromeDriver)driver, "class", "sc-fzoYkl jRkIgn", "login");
      InputByClass((ChromeDriver)driver, "class", "sc-fzoYkl jRkIgp", "password");
      GetElement((ChromeDriver)driver, "button", "class", "sc-oTbqq cHPZj").Click();
      Thread.Sleep(2000);
      bool dashboardElement = true;

      try
      {
          GetElement((ChromeDriver)driver, "span", "class", "sc-oTzgz nnuJi");
      }
      catch (Exception)
      {
          dashboardElement = false;
      }

      Assert.True(dashboardElement);
  }
```

https://user-images.githubusercontent.com/62616833/173202143-d04cc0b1-8e29-40c3-b70e-9938e4353708.mp4

## Kontakt
Aplikację stworzyli:
Natalia Gościnna & Damian Jaszewski
