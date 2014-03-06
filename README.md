TimesheetReminder
=================

Status:
- Completed

Used technologies:
- Windows service
- Mail sending and composing
- Threads

Used design patterns:
- Strategy

Story:

In the company where I work some scatterbrained software developers permanently forget to complete timesheet. 
All of us know how important it is. There's no better way to focus developer's brain on some task 
than combine it with female beauty. Once upon a time great tradition was born, tradition of sending
photos of chicks at 16 PM to all scatterbrained devs. Since then no lacks in timesheet completion
have been observed. However our code hasn't been perfect. It has been sending same girls repeatedly.
Girls sometimes were too plastic. So I decided to improve our legendary reminder mechanism, by
recreating it...

Result:

Configurable windows service which sends e-mails to defined recipient list
with embedded photo extracted from given tumblr page. Page, recipient list, e-mail account settings, hour,
reminding e-mail subject and body - are configurable through XML.
