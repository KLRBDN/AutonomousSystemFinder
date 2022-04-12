# AutonomousSystemFinder
Скрипт принимает ip или домен и выводит на консоль таблицу с информацией о маршрутизаторах, по которым прошел пакет.
Для каждого маршрутизатора указан ip, автономная система, а также страна и провайдер, если их удалось получить (Иначе стоит "-").

Скрипт можно запустить через консоль (.exe находится в bin\Debug\net5.0\Internet Protocols. Task 1.exe), аргументом является ip или доменное имя, например "Internet Protocols. Task 1".exe 123.123.123.123 или "Internet Protocols. Task 1".exe Yandex.ru.
Если адрес некорректен или время ожидания ответа превышено, то будет выброшена соответствующая ошибка.
Также скрипт можно запустить, открыв файл с расширением .csproj. После этого нужно будет открыть класс Program.cs и поменять значение переменной defaultArg с null на нужный адрес/домен. Например, string defaultArg = "Google.com" или string defaultArg = "74.125.77.147".

Примеры запуска:
1. "Internet Protocols. Task 1".exe Google.com - сработает правильно.
2. "Internet Protocols. Task 1".exe 123 - выдаст ошибку.
3. "Internet Protocols. Task 1".exe 74.125.77.147 - сработает правильно.

Овчинников Павел, КН-202
