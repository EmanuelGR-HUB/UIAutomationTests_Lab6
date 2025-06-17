using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System;

namespace UIAutomationTests
{
    public class Selenium
    {
        EdgeDriver _driver;
        WebDriverWait _wait;

        [SetUp]
        public void Setup()
        {
            _driver = new EdgeDriver();
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        }
        [Test]
        public void Crear_Pais_Y_Verificar_Confirmacion_Y_En_Lista_Test()
        {
            var URL = "http://localhost:8080/";
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl(URL);

            // Se hace click en el botón "Agregar país", una vez se haya cargado la página
            var agregarBtn = _wait.Until(driver => driver.FindElement(By.XPath("//button[contains(text(),'Agregar país')]")));
            agregarBtn.Click();

            // Se espera que estén disponibles los campos y luego se llenan
            _wait.Until(driver => driver.FindElement(By.Id("nombre"))).SendKeys("PruebaSeleniumPais6");
            _driver.FindElement(By.Id("continente")).SendKeys("Europa");
            _driver.FindElement(By.Id("idioma")).SendKeys("PruebaSeleniumIdioma6");

            // Se hace click en el botón "Guardar"
            _driver.FindElement(By.XPath("//button[contains(text(),'Guardar')]")).Click();

            // Se espera a que el país aparezca en la lista y luego se verifica para ver si está
            _wait.Until(driver => driver.PageSource.Contains("PruebaSeleniumPais6"));
            Assert.IsTrue(_driver.PageSource.Contains("PruebaSeleniumPais6"), "El país no aparece en la lista.");
        }
    }
}