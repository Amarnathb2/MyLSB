# Lincoln Savings Bank

Originally developed by [Marshall Annis](mailto:mannis@zaginteractive.com).

- Dev: [https://mylsb-dev.zagclients.net](https://mylsb-dev.zagclients.net)
- QA: [https://mylsb-qa.zagclients.net](https://mylsb-qa.zagclients.net)
- Prod: [https://www.bankofmissouri.com](https://www.mylsb.com/)

Lincoln Savings Bank is built in Kentico 13 MVC with Bootstrap 4.
Site is load balanced.

## Reusable Content
All reusable content items (Alerts, Promos, Resources, etc) are placed within folders under /Reusable Content.

## Templates

### Page
Most pages on the site use the "Page" template. This page conatins a few non standard properties:
- Insurance Disclosure: Enable this setting to display an alternate disclosure in the footer. The disclosure content is managed on the Settings node. This setting is primarily used on the Insurance pages.
- Footer Emblems: On by default but can be disabled to hide the Equal Housing, FDIC, etc. logos in the footer. Used primarily on Wealth management pages.

### Page Group
Level 2 pages used for grouping page categories. Add the icon and a promo which gets displayed when using the Section subpages component.

### Landing Page
Use special Landing Masthead and Landing Content components on these pages.

### Locations &amp; Location Detail
The Locations module uses our standard Kentico 13 Core starter kit implementation

## Calculators
Site uses Fintactix calculators. They are adde to the page using the calculator component. All that needs to be entered is the calculator URL, which gets iframed on to the page.

## Forms
Besides standard Kentico forms the site also has some embedded HubSpot forms and a custom form

### HubSpot forms
For forms that are managed on Hubspot, these are added to the page using the "HubSpot Form" component. The component needs to be configured with the Portal ID and Form ID.
All other configuration of the form is handled by the client within thier HubSpot account.

### Custom form: Change Order Request
The change order request form exists as a Kentico form for the purpose of recording submitted data, but the front end is a custom view component. Any changes to the form display on the front end site must be made in the view component markup and not through the the form builder.
