Требования к работе утилиты:
1) ОС - Windows,
2) .NET Framework 4.8

Параметры команды:

Флаги (необязательно, для большего контроля над процессом нанесения qr-кода):

--qr_dark_color=color (Цвет темной части qr-кода, где color-наименование цвета в виде red,green,blue и т.д., или шестнадцатиричный rgb-код в виде #FFFFFF, где первые FF-задают степень красного, вторые - зелёного, третьи - синего компонентов цвета)

--qr_light_color=color(Цвет светлой части qr-кода)

--std_pos=позиция qr-кода в пределах документа (1-левый верхний угол, 2-правый верхний, 3-правый нижний, 4-левый нижний, итого - по часовой стрелке)

--std_poss=перечень позиций, разделенных запятой (например --std_poss=1,3 означает нанести код в левом верхнем и правом нижнем углах документа)


Данные, последовательно:
1 - путь к исходному документу (если утилита выполняется в папке с документом, то достаточно указать имя с учётом расширения, например output.pdf)
2 - текст для кодирования (если текст содержит пробелы, то его необходимо заключить в двойные кавычки ")
3 - путь к выходному документу (если требуется сгенерировать документ в папке, где выполняется утилита, достаточно указать имя с учётом расширения, например output.pdf)


Порядок передачи параметров произволен. Важен только относительный порядок следования данных, который приведён выше.
Но по устоявшимся соглашениям сначала передаются необходимые флаги, затем - входные данные
