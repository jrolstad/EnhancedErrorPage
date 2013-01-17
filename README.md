EnhancedErrorPage
=================

Description
-----------
This is meant to be a replacement for the standard 'Yellow Screen of Death' seen in standard ASP.NET MVC applications.

Some of the features are:

+ Searchability: The Exception messages, sources, and stack traces all are links that search for that text on Google
+ Server Details: Information such as the server name, time, and user context are shown
+ Server Variables
+ Request Parameters
+ Headers
+ Cookies
+ Form Values

This is all laid out on a single page, using some UI components from the KendoUI library.

How to Install
-----------
This can be found on nuget at http://nuget.org/packages/EnhancedErrorPage.MVC

The installation will install the source code and override the existing Error.cshtml.  In order to enable the page, be sure to turn on custom errors in the application web.config

Demo
----
A working example can be found at http://enhancederrorpage.apphb.com
