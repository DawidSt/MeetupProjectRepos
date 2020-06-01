SPECYFIKACJA WYMAGAŃ

DLA: MeetupProjectRepos

WERSJA: 1

AUTORZY: Dawid Stanclik, Justyna Luszczak, Dawid Charęza


MeetupProjectRepos

Aplikacja stworzona na potrzeby przedmiotu "Zespołowe przedsięwzięcie programistyczne"

Opis wymagań:

Celem projektu jest stworzenie aplikacji internetowej, która służyć ma do organizowania meetapów. Pozwoli to na proste tworzenie oraz śledzenie meetupów

Wymagania funkcjonalne:

•	wyświetlanie listy meetapów
•	wprowadzanie nowych meetapów
•	możliwość edycji meetupu
•	rejestracja użytkownika 
•	możliwość dodawania wystąpień w danym meetupie

Wymagania niefunkcjonalne:

•	interfejs: aplikacja internetowa
•	dostęp z poziomu przeglądarki internetowej
•	system nie może udostępniać informacji jeśli użytkownik się nie zalogował
•	system otwarty na rozbudowę
•	system oraz klient muszą mieć dostęp do internetu

Opis architektury i wybór technologii:

Aplikacja hostowana będzie jako Web API pod ASP.NET Core wraz z połączeniem bazodanowym do MSSQL. Front-end aplikacji będzie stworzony w oparciu o ReactJS.

Używane technologie:

•	ASP.NET Core Web API (C#)
•	Entity Framework Core
•	Baza danych MSSQL
•	FluentValidation
•	Front-end aplikacji: ReactJS

Standardowy przypadek użycia

•	Użytkownik tworzy konto w systemie a następnie się loguje
•	Użytkownik tworzy meetup
•	Użytkownik ma stały dostęp do podglądu oraz edycji listy meetupów
•	Użytkownik może dodawać wystąpienie w obrębie meetupu

