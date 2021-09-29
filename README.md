# Flappy-bird (Котофлэп)

![Gameplay](/ReadmeImages/Gameplay.gif)

## Задача
Необходимо создать игру “Flappy Bird” (см. https://www.youtube.com/watch?v=fQoJZuBwrkU ) в Unity3d с использованием Di-контейнера Zenject. Задачу необходимо декомпозировать и декомпозицию предоставить в отчете.
Игра должна работать на PC/Android, сохранять свое состояние между сессиями, в игре должно быть три экрана:

**Главное меню**
Старт - Начать игру
1) Очки - Отображается окно с максимально набранным скором и кнопкой “Закрыть”
2) Настройки - Отображается окно настроек, в котором есть кнопка включения/отключения звука и кнопка “Закрыть”
3) Игра должна сохранять свое состояние между сессиями.

**Игровой процесс**
На экране игрового процесса (после нажатия кнопки “Старт”) - игрок должен видеть “Очки” и на экране должна быть кнопка “Пауза”, при нажатии на которую - экран затемняется, и есть две кнопки - “Продолжить” и “Выход в меню”.
Геймплей должен быть как на ролике выше.

**Поражение**
После поражения игроку отображается окно проигрыша, на котором есть
1) Текущие набранные очки 
2) Максимально набранные очки (рекорд)
3) Кнопка “Выход в меню”

## Коментарии к выполненной задаче
Старался по максимуму использовать di-контейнеры (Zenject) и OOD. Делал 1.09.2021 - 5.09.2021, время не засекал, но примерно 30-40 часов вместе с изучением zenjecta и обдумыванием архитектуры на нём.
