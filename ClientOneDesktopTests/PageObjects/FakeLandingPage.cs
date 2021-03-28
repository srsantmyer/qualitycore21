using System;
using QACoreTests;

namespace ClientOneDesktopTests.PageObjects
{
    public static class FakeLandingPage
    {
        public static BaseElement link_Courses = ElementFactory.LinkText("Courses");
        // this button doesn't do anything?
        public static BaseElement btn_ViewCourses = ElementFactory.Xpath("//a[contains(text(), 'View Courses')]");
    }
}