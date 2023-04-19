using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace SQA_07_SyedTaimoorAli_OrangeHRM
{    
    public class BasePage
    {
        public static IWebDriver driver;
        public static ExtentReports extentReports;
        public static ExtentTest ParentTest;
        public static ExtentTest ChildTest;
        public static string dirpath;
        public static void SeleniumInitialization(string browser)
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }
        public static void LogReport(string testcase)
        {
            extentReports = new ExtentReports();
            dirpath = @"..\..\ExtentReport\" + '_' + testcase;
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(dirpath);
            htmlReporter.Config.Theme = Theme.Standard;
            extentReports.AttachReporter(htmlReporter);
        }
        public static void TakeScreenshots(Status status, string stepDetail)
        {
            string path = @"C:\Users\AliiiTai\source\repos\SQA_07_SyedTaimoorAli_OrangeHRM\SQA_07_SyedTaimoorAli_OrangeHRM\Screenshorts\" + "ExtentReportLog_" + DateTime.Now.ToString("yyyyMMddHHmmss");
            Screenshot image_username = ((ITakesScreenshot)driver).GetScreenshot();
            image_username.SaveAsFile(path + ".png", ScreenshotImageFormat.Png);
            ChildTest.Log(status, stepDetail, MediaEntityBuilder.CreateScreenCaptureFromPath(path + ".png").Build());
        }
        public static void SeleniumClose()
        {
            driver.Close();
            driver.Quit();
        }
        public static void Write(By by, string Data)
        {
            try
            {
                driver.FindElement(by).SendKeys(Data);
                Thread.Sleep(3000);
                TakeScreenshots(Status.Pass, "Write");
            }
            catch(Exception ex)
            {
                TakeScreenshots(Status.Fail, "Failed to Write" + ex);
            }
        }
        public static void Click(By by)
        {
            try
            {
                driver.FindElement(by).Click();
                Thread.Sleep(3000);
                TakeScreenshots(Status.Pass, "Click");
            }
            catch (Exception ex)
            {
                TakeScreenshots(Status.Fail, "Failed to Click" + ex);
            }
        }
        public static void Clear(By by)
        {
            try
            {
                driver.FindElement(by).Clear();
                Thread.Sleep(3000);
                TakeScreenshots(Status.Pass, "Clear");
            }
            catch (Exception ex)
            {
                TakeScreenshots(Status.Fail, "Failed to Clear" + ex);
            }
        }
        public static void OpenUrl(string url)
        {
            try
            {
                driver.Url = url;
                Thread.Sleep(3000);
                TakeScreenshots(Status.Pass, "Open Url");
            }
            catch (Exception ex)
            {
                TakeScreenshots(Status.Fail, "Failed to Open Url" + ex);
            }
        }
        public static void Goto(string url)
        {
            try
            {
                driver.Navigate().GoToUrl(url);
                Thread.Sleep(3000);
                TakeScreenshots(Status.Pass, "Goto Url");
            }
            catch (Exception ex)
            {
                TakeScreenshots(Status.Fail, "Failed to Open Url" + ex);
            }
        }
    }
}
