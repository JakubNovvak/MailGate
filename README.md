<!-- PROJECT LOGO -->
<br />
<div align="center" style="text-align: center;">
  <a href="https://github.com/JakubNovvak/MailGate">
    <img src="https://i.ibb.co/JmRHNnY/Mail-Gate-Logo.png" alt="Logo" width="110" height="110">
  </a>

  <h3 align="center">MailGate</h3>

  <p align="center">
    Anonymous Messaging Service
    <br />
    
</div>





<!-- ABOUT THE PROJECT -->
## About The Project

![Product Name Screen Shot][product-screenshot]

MailGate is a anonymous mailing service, allowing to send single messages to the chosen email address. The idea of the project is to give users the possiblity to send messages without the need to register, while staying anonymous.

The future objective of development is to:
- Give users the ability to send email with attachments
- Implement Admin account
- Implement dashboard of managing the email entries in the database

Project was designed using standard Client and Server distinction, with the Server side being divided into four seperate projects based on the Onion Architecture.
## Current Stage of Development

At the moment there is only sending message functionality - as metioned before, new features like admin dashboard will be added in the future of the development.

<p align="right">(<a href="#readme-top">back to top</a>)</p>

### Built With


* [![.NET][.NetCsharp]][.NetCsharp-url]
* [![Asp][Aspnet]][Aspnet-url]
* [![Reacts][React.ts]][React-url]

<p align="right">(<a href="#readme-top">back to top</a>)</p>

<!-- GETTING STARTED -->
## Getting Started

Connection is hard coded, so there is no reason to configure it on a local machine. In terms of testing email sending feature, you need to:
1. Create a new gmail accout (or use an already created one)
2. Go to your security settings and choose "2-Step Verification"
3. At the bottom of the page, choose "App passwords"
4. Create a new App Key and paste it with your email address in the "Source/Config/apinconfig.json" file
``` json
{
  "userName": "<your-gmail-address>",
  "AppPassword": "<your-16-digit-gmail-app-password>"
}
```

<!-- ROADMAP -->
## Roadmap

- [x] Usable client and server projects
- [x] Sending data from the Client
- [x] Forwarding email on the Server
- [x] Stable version with hosted frontend demo
- [ ] Captcha soft security precaution
- [ ] Sending attachments with the email
- [ ] Admin dashboard

<p align="right">(<a href="#readme-top">back to top</a>)</p>


<!-- CONTACT -->
## Contact

Jakub Nowak - [@LinkedIn Profile](https://www.linkedin.com/in/jakub-nowak-a245312b7/)
<br/> jakubszymonnowak@gmail.com

Project Link: [github.com/JakubNovvak/MailGate](https://github.com/JakubNovvak/MailGate)

<p align="right">(<a href="#readme-top">back to top</a>)</p>


<!-- MARKDOWN LINKS & IMAGES -->
[product-screenshot]: https://i.ibb.co/FJVZ1Pq/obraz-2024-03-01-133414758.png
[.NetCsharp]: https://img.shields.io/badge/-.NET%208.0%20%7C%20%20C%23%2012.0-blueviolet?style=for-the-badge
[.NetCsharp-url]: https://dotnet.microsoft.com/en-us/
[React.ts]: https://img.shields.io/badge/React.ts-20232A?style=for-the-badge&logo=react&logoColor=61DAFB
[React-url]: https://react.dev/learn/typescript
[Aspnet]: https://img.shields.io/badge/.Asp.Net%20Core-darkviolet?style=for-the-badge
[Aspnet-url]: https://dotnet.microsoft.com/en-us/apps/aspnet
