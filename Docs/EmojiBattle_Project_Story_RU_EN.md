# Emoji Battle Project Story - RU / EN

This document is a practice script for explaining Emoji Battle in Russian and English.
It is based on the actual Unity project structure, scripts, scenes, assets, README, and project settings.

## Confirmed Project Facts

- Project name in Unity/README: Emoji Battle.
- Visual loading screenshot currently shows "Emoji Duels", so the public branding should be kept consistent when presenting the project.
- Engine: Unity 6, version 6000.3.5f2.
- Main platform: Android.
- Package name: com.sd7gamestudio.emojibattle.
- Version in ProjectSettings: 1.0.6, Android version code 6.
- Build scenes: Bootstrap, Lobby, Main.
- Code size: 90 C# scripts under Assets/Scripts.
- Emoji content: 9 ScriptableObject color sets, 87 emoji sprites per color.
- Main technologies: C#, UGUI, TextMesh Pro, URP, DOTween, Unity Ads, PlayerPrefs JSON saves.

---

# Russian Version

## Короткая версия на 15 секунд

Emoji Battle - это мобильная puzzle-battle игра на Unity для Android, вдохновленная крестиками-ноликами, но расширенная системой эмодзи, выбором персонажей, AI-соперниками, прогрессией, наградами, попапами, звуком, вибрацией и рекламой. Я разработал проект как полноценную мобильную игру: от игровой логики и архитектуры до UI, сохранений, монетизации и релиза.

## Версия на 30-45 секунд

Emoji Battle - это опубликованная мобильная игра на Unity 6 для Android. Игрок выбирает эмодзи-персонажа, цвет, сложность AI и играет матч на поле 3x3. Базовая механика похожа на tic-tac-toe, но я сделал ее более игровой за счет визуальных эффектов, прогрессии, разблокировки новых эмодзи, звуков, вибрации, попапов победы/поражения и rewarded ads.

Главный технический фокус проекта был в том, чтобы не сделать обычный "UI spaghetti" проект. Я разделил игровую логику, UI и инфраструктуру: BoardState и WinChecker отвечают за правила, AI реализован через Strategy pattern, прогресс и сохранения вынесены в отдельные сервисы, а сцены собираются через installer/controller слой. Благодаря этому игру легче поддерживать, расширять и тестировать.

## Полная версия на 2-3 минуты

Emoji Battle - это мой мобильный Unity-проект, который я довел до состояния готовой игры и Android-релиза. Это небольшая, но законченная puzzle-battle игра. Игрок заходит через Bootstrap-сцену, попадает в Lobby, выбирает свой эмодзи, цвет и сложность противника, затем запускает матч в Main-сцене.

Основная механика похожа на крестики-нолики: игрок и AI по очереди ставят свои эмодзи на поле 3x3. Победа определяется по горизонталям, вертикалям и диагоналям. Но я расширил простую механику в полноценный мобильный игровой цикл: выбор персонажа, AI-сложности, прогрессия, разблокировка новых эмодзи, rewarded ads, interstitial ads, настройки звука, музыки и вибрации, а также визуальные эффекты через DOTween и dissolve-анимации.

В проекте есть 9 цветовых наборов эмодзи, по 87 эмодзи в каждом цвете. Данные по эмодзи хранятся в ScriptableObject-конфигах, а прогресс игрока сохраняется в JSON через PlayerPrefs. При первом запуске игрок получает стартовый набор открытых эмодзи, а дальше открывает новые за победы или через rewarded ads. Награды зависят от сложности: easy, normal и hard открывают разные диапазоны эмодзи.

Самая важная часть проекта для меня - архитектура. Я старался разделять ответственность классов. Доменная логика доски находится отдельно от Unity UI. BoardState хранит состояние клеток, WinChecker проверяет победу или ничью, GameFlow управляет ходами и сообщает о событиях. UI не решает, кто победил, а только отображает результат. AI вынесен в отдельные стратегии: EasyStrategy, NormalStrategy и HardStrategy. AIStrategyFactory выбирает нужную стратегию по сложности, поэтому новую сложность можно добавить без переписывания всего игрового цикла.

На уровне сцен я использовал installer/controller подход. Например, MainInstaller создает BoardState, WinChecker, GameFlow, GameRewardService, GameResultController и MainController, а также передает им ссылки на view-компоненты из сцены. Это работает как простой composition root. Такой подход позволяет не использовать FindObjectOfType или GameObject.Find в runtime-логике и делает зависимости более явными.

В проекте также есть инфраструктурные сервисы: GameDataService для сохранений, AudioService для музыки и SFX, SettingsService для настроек, InternetService для проверки соединения, AdsService для Unity Ads, PopupService для управления попапами и VibrationService для мобильной отдачи. Большинство сервисов создаются один раз в Bootstrap-сцене и живут между сценами через DontDestroyOnLoad.

Главные проблемы, которые я решал в проекте, были связаны не только с gameplay, но и с production-частью. Нужно было сделать так, чтобы игра корректно работала после смены сцен, чтобы подписки на события не протекали, чтобы реклама не ломала UI, чтобы отсутствие интернета показывало понятный сценарий, чтобы сохранения не сбрасывались случайно, а прогресс оставался расширяемым. Для этого я использовал явные события, Dispose/OnDestroy отписки, отдельные состояния рекламы, versioned save payload и отдельные popup-сценарии для разных результатов.

С точки зрения производительности проект легкий: поле всего 3x3, нет тяжелой физики и нет постоянных поисков объектов в Update. UI-список эмодзи пересобирается только при смене цвета, а не каждый кадр. Для Android это достаточно безопасно. При этом я понимаю, что в будущем можно было бы улучшить emoji scroll view через object pooling, закешировать некоторые component references и добавить unit tests для BoardState, WinChecker, AI и GameProgress.

Для меня этот проект важен тем, что это не просто учебный прототип. Это end-to-end опыт: я сделал gameplay, UI, архитектуру, сохранения, мобильные сервисы, рекламу, сборку и подготовку к публикации. Этот проект хорошо показывает меня как Unity/C# разработчика, который думает не только о том, чтобы "оно работало", но и о поддержке, жизненном цикле, расширяемости и качестве кода.

## Что делает игрок

1. Игрок запускает игру и видит Bootstrap/loading экран.
2. Игра загружает Lobby-сцену и создает основные сервисы.
3. В лобби игрок выбирает цвет и эмодзи.
4. Игрок выбирает сложность AI: Easy, Normal или Hard.
5. Игрок нажимает Start и переходит в Main-сцену.
6. Игрок и AI по очереди делают ходы на поле 3x3.
7. После победы, поражения или ничьей показывается соответствующий popup.
8. При победе игрок может открыть новый эмодзи, если правила прогрессии это разрешают.
9. Rewarded ads дают альтернативный способ открыть эмодзи.
10. Настройки позволяют изменить имя, музыку, SFX и вибрацию.

## Моя роль в проекте

Я отвечал за полный цикл разработки мобильной Unity-игры:

- проектирование gameplay loop;
- реализацию правил игры 3x3;
- реализацию AI с несколькими уровнями сложности;
- создание системы выбора и разблокировки эмодзи;
- сохранение прогресса и настроек игрока;
- построение UI для лобби, матча, настроек и попапов;
- интеграцию звука, музыки, вибрации и визуальных эффектов;
- интеграцию Unity Ads;
- обработку состояния интернета;
- подготовку Android build settings, privacy policy и Google Play release;
- рефакторинг архитектуры под SRP и MVC-style separation.

## Архитектура простыми словами

Проект разделен на несколько слоев.

Domain layer отвечает за чистые игровые правила. Здесь находятся BoardState, WinChecker, WinResult, CellState, AI strategies, EmojiProgress и RewardRules. Эти классы почти не зависят от Unity UI.

Presentation layer отвечает за отображение и пользовательский ввод. Здесь находятся BoardView, MainUIView, LobbyView, EmojiScrollView, PopupBase, PopupService, SettingsPopup и визуальные анимации.

Infrastructure layer отвечает за данные и сохранение. Здесь находятся SavePayload, PlayerProfile, AIProfile, GameProgress, IDataStorage и PlayerPrefsStorage.

Services layer отвечает за глобальные сервисы игры: AudioService, AdsService, SettingsService, InternetService и VibrationService.

App layer отвечает за запуск проекта и начальную сборку сервисов: EntryPointBootstrap, BootstrapController и BootstrapView.

Главный принцип: gameplay rules не должны жить внутри UI-компонентов. UI может показать кнопку, эмодзи или popup, но не должен решать правила победы, прогрессии или AI.

## Ключевые системы

### Core gameplay

BoardState хранит состояние поля 3x3. GameFlow принимает ход игрока или AI, записывает состояние, вызывает событие OnMoveApplied, проверяет результат через WinChecker и переключает очередь хода. WinChecker отдельно проверяет победу, ничью и линию победы.

Почему это хорошо: правила игры находятся в одном понятном месте и не смешаны с кнопками, анимациями и сценой.

### AI

AI построен через интерфейс IAIStrategy. Есть EasyStrategy, NormalStrategy и HardStrategy. Разные уровни сложности используют разные вероятности: AI может попытаться выиграть, заблокировать игрока, взять центр, угол или сделать случайный ход.

Почему это хорошо: сложность AI можно менять без изменения GameFlow. GameFlow знает только, что стратегия возвращает индекс клетки.

### Emoji customization

Каждый цвет эмодзи хранится в отдельном EmojiData ScriptableObject. EmojiResolver строит словарь по ColorId и быстро возвращает нужный Sprite по цвету и индексу. Прогресс хранит, какие эмодзи открыты.

Почему это хорошо: контент отделен от кода. Можно добавлять или менять наборы эмодзи через Unity Inspector.

### Progression and rewards

GameProgress хранит список EmojiProgress, порядок разблокировки, указатели прогресса по сложности и последний открытый эмодзи. RewardRules задает диапазоны наград по сложности: Easy, Normal и Hard открывают разные диапазоны.

Почему это хорошо: игрок получает понятную progression loop, а баланс можно менять в одном месте.

### Saving

GameDataService загружает и сохраняет SavePayload через PlayerPrefsStorage. Данные сериализуются в JSON через JsonUtility. SavePayload содержит PlayerProfile, AIProfile, GameProgress, SettingsData, флаг первого запуска и версию сохранения.

Почему это хорошо: сохранение простое, подходит для небольшой mobile game, и уже есть SaveVersion для будущих миграций.

### Popups

PopupService управляет текущим popup, overlay и контекстом сцены. PopupBase отвечает за show/hide animation, CanvasGroup, звук и вибрацию. ResultPopup добавляет событие Closed, чтобы после закрытия результата можно было перезапустить матч.

Почему это хорошо: попапы имеют общий базовый lifecycle, а конкретные попапы отвечают только за свой контент.

### Audio, vibration and settings

AudioService играет музыку плейлистом и SFX через SoundDefinition. SettingsService сохраняет музыку, SFX, громкость, вибрацию и имя игрока. VibrationService дает мобильную отдачу.

Почему это хорошо: UI не работает напрямую с AudioSource или PlayerPrefs. Он вызывает сервисы.

### Ads and internet state

AdsService работает с Unity Ads, rewarded ads и interstitial ads. Он хранит RewardedState: Offline, Initializing, Loading, Ready, Showing, Failed. InternetService проверяет Application.internetReachability и сообщает об изменении состояния сети.

Почему это хорошо: UI может показывать loading/connecting/offline state, а игрок получает понятную обратную связь, если рекламы или интернета нет.

## Проблемы и как я их решил

### Проблема 1: простая игра может быстро превратиться в UI spaghetti

Если писать всю логику прямо в MonoBehaviour кнопок, то проект быстро становится трудно поддерживать. UI начинает отвечать за правила, AI, сохранения и попапы.

Решение: я разделил проект на Domain, Presentation, Infrastructure, Services и App. GameFlow управляет ходами, BoardState хранит состояние, WinChecker проверяет результат, а UI только отображает изменения.

Что это показывает обо мне: я понимаю SRP и стараюсь строить поддерживаемую архитектуру даже в небольших проектах.

### Проблема 2: нужно было сделать AI, который ощущается по-разному на разных сложностях

Обычный random AI слишком слабый, а идеальный AI мог сделать игру скучной.

Решение: я сделал Strategy pattern. Easy, Normal и Hard используют разные вероятности для умных действий: попытаться победить, заблокировать игрока, взять центр или угол. Это дает ощущение сложности, но оставляет игре немного непредсказуемости.

Что это показывает обо мне: я умею выбирать не только технически правильное, но и gameplay-подходящее решение.

### Проблема 3: в игре много эмодзи, и прогресс должен оставаться понятным

В проекте 9 цветов по 87 эмодзи. Если хранить все хаотично, легко получить баги с unlock state, сортировкой и выбранными персонажами.

Решение: я вынес наборы эмодзи в EmojiData ScriptableObjects, а прогресс храню через EmojiProgress и GameProgress. EmojiResolver отделяет доступ к Sprite от UI. Разблокировка работает по ColorId и EmojiId.

Что это показывает обо мне: я умею отделять контент, данные и UI.

### Проблема 4: награды должны зависеть от сложности

Если награды случайные без правил, игроку трудно понять progression loop.

Решение: RewardRules задает диапазоны для Easy, Normal и Hard. GameRewardService решает, можно ли открыть новый эмодзи, учитывает победителя, сложность, интернет и состояние "все открыто".

Что это показывает обо мне: я могу проектировать не только код, но и progression/balance rules.

### Проблема 5: сервисы должны переживать смену сцен

Audio, Ads, Popup, Internet и Vibration нужны на разных сценах. Если создавать их заново без контроля, появятся дубликаты и баги.

Решение: EntryPointBootstrap создает сервисы один раз, а сервисы используют DontDestroyOnLoad и singleton guard. Сцены передают PopupService новый context через SetContext.

Что это показывает обо мне: я понимаю Unity lifecycle и проблемы смены сцен.

### Проблема 6: отсутствие интернета и реклама не должны ломать UX

Rewarded ads зависят от сети и готовности Unity Ads. Если UI не знает состояние рекламы, игрок может нажать кнопку и ничего не получить.

Решение: AdsService хранит явное состояние rewarded ads, LobbyController переводит его в AdsUiModel, а LobbyView показывает button alpha, loading или connecting state. Если интернета нет, показывается NoInternet popup.

Что это показывает обо мне: я думаю о реальном mobile UX, а не только о happy path.

### Проблема 7: нужно было избежать event leaks

В Unity легко забыть отписаться от событий при смене сцены, особенно когда есть DontDestroyOnLoad сервисы.

Решение: controllers реализуют Dispose, MonoBehaviour-компоненты отписываются в OnDestroy, popups снимают listener callbacks, а сервисы отписываются от статических событий.

Что это показывает обо мне: я обращаю внимание на lifecycle и memory leaks.

### Проблема 8: игра должна выглядеть живой, но оставаться легкой

Простая grid-игра может выглядеть сухо.

Решение: я добавил neon UI style, DOTween popup animations, dissolve-анимации эмодзи, win line animation, particles, SFX, music playlist и vibration feedback. При этом логика остается легкой, без тяжелой физики и без постоянных runtime-search операций.

Что это показывает обо мне: я умею соединять техническую архитектуру и игровое ощущение.

## Производительность и память

Проект достаточно легкий для Android: поле маленькое, ходовая логика выполняется только по клику или после AI delay, а не каждый кадр. В горячих Update/FixedUpdate циклах нет тяжелой игровой логики. Зависимости в основном передаются через SerializeField или создаются в installer слой, а не ищутся через FindObjectOfType.

Что уже хорошо:

- нет runtime GameObject.Find/FindObjectOfType в игровой логике;
- core gameplay не зависит от тяжелых Unity objects;
- EmojiResolver использует Dictionary для доступа по ColorId;
- события отписываются при Destroy/Dispose;
- DOTween tweens убиваются в OnDestroy/OnDisable;
- сервисы создаются один раз и не дублируются между сценами.

Что можно улучшить:

- EmojiScrollView сейчас уничтожает и создает кнопки заново при смене цвета. Для текущего масштаба это нормально, но для более тяжелого UI лучше использовать object pooling.
- BoardState.Data возвращает clone массива. Для поля 3x3 это не проблема, но в более крупной игре лучше избегать лишних копий или отдавать readonly snapshot.
- AI strategies создают List<int> при расчете хода. Для 3x3 это безопасно, но на мобильных проектах с частыми вызовами лучше переиспользовать буферы.
- BoardView вызывает TryGetComponent при ходе и reset. Это не критично для 9 кнопок, но можно закешировать DissolveMain references в Awake.
- В будущем полезно добавить unit tests для BoardState, WinChecker, GameProgress и AI strategies.

## Что я бы улучшил в следующей версии

1. Добавил бы отдельные Assembly Definitions для Domain, Presentation, Services и Infrastructure.
2. Добавил бы EditMode tests для логики доски, победы, ничьи, AI и прогрессии.
3. Перевел бы EmojiScrollView на pooling, чтобы не пересоздавать UI-элементы.
4. Закешировал бы DissolveMain и TMP_Text references там, где сейчас есть GetComponentInChildren.
5. Добавил бы migration logic для будущих версий SavePayload.
6. Сделал бы branding полностью единым: Emoji Battle или Emoji Duels.
7. Добавил бы аналитику gameplay funnel: start match, win, defeat, rewarded viewed, emoji unlocked.
8. Добавил бы больше баланса для AI, например minimax mode для hard или adaptive difficulty.
9. Улучшил бы accessibility: readable contrast, reduced motion option, larger buttons for small screens.

## Как рассказать о себе через этот проект

Я могу сказать, что этот проект показывает меня как Unity/C# разработчика, который умеет доводить игру до конца. Я не ограничился прототипом механики. Я сделал полный мобильный игровой цикл: загрузка, лобби, выбор персонажа, матч, AI, победа/поражение, награды, сохранения, звук, вибрация, реклама и Android-релиз.

Также проект показывает, что я думаю об архитектуре. Я разделяю данные, игровую логику и представление. Я стараюсь избегать god objects и скрытых зависимостей. Я понимаю Unity lifecycle, подписки на события, проблемы смены сцен и mobile performance. Для меня важно, чтобы проект был не только рабочим, но и поддерживаемым.

## Ответы для интервью на русском

### Вопрос: Расскажи о своем проекте Emoji Battle

Emoji Battle - это мобильная puzzle-battle игра на Unity 6 для Android. Игра основана на механике 3x3, похожей на tic-tac-toe, но расширена системой кастомизации эмодзи, AI-соперниками, progression loop, rewarded ads, настройками, звуком, вибрацией и визуальными эффектами. Я реализовал весь цикл: gameplay logic, UI, saves, AI, rewards, ads integration и подготовку к релизу.

### Вопрос: Какая была самая сложная часть?

Самой сложной частью было не само поле 3x3, а превращение простой механики в полноценный мобильный продукт. Нужно было разделить UI и логику, сделать понятную прогрессию, сохранить данные игрока, обработать рекламу и интернет, а также не получить хаотичную архитектуру. Я решил это через разделение на слои, controller/installer подход, отдельные сервисы и event-based communication.

### Вопрос: Как устроен AI?

AI построен через Strategy pattern. Есть общий интерфейс IAIStrategy и три реализации: Easy, Normal и Hard. Каждая стратегия принимает текущий board state и возвращает индекс хода. Easy чаще делает случайные ходы, Normal чаще блокирует и пытается выиграть, Hard почти всегда ищет выигрышный ход и чаще блокирует игрока. GameFlow не знает деталей AI, поэтому сложность можно менять независимо.

### Вопрос: Как ты работал с сохранениями?

Я сделал GameDataService, который хранит SavePayload. SavePayload содержит профиль игрока, профиль AI, прогресс эмодзи, настройки и версию сохранения. Данные сериализуются в JSON и сохраняются через PlayerPrefs. Для небольшой мобильной игры это простой и достаточный подход. Я также добавил SaveVersion, чтобы в будущем можно было делать миграции.

### Вопрос: Что ты сделал для производительности?

Я избегал постоянных поисков объектов в runtime logic, не использовал тяжелую логику в Update, держал core gameplay независимым от Unity UI и использовал явные ссылки через SerializeField и installer слой. В проекте маленькое поле 3x3, поэтому основные операции дешевые. При этом я вижу места для улучшения: pooling для emoji scroll list, кеширование некоторых component references и unit tests.

### Вопрос: Что бы ты улучшил сейчас?

Я бы добавил automated tests для domain logic, перевел бы динамический список эмодзи на pooling, добавил бы отдельные asmdef для слоев архитектуры, улучшил бы save migrations и сделал бы branding полностью единым. Также можно развить AI, например добавить minimax для hard mode или adaptive difficulty.

---

# English Version

## 15-second version

Emoji Battle is a mobile puzzle-battle game built with Unity for Android. It is inspired by tic-tac-toe, but I expanded it with emoji customization, AI opponents, progression, unlockable rewards, popups, sound, vibration, ads, and a mobile-first UI. I built it as a complete game, from gameplay architecture to saving, services, and release preparation.

## 30-45 second version

Emoji Battle is a shipped Android game built in Unity 6. The player chooses an emoji character, a color, and an AI difficulty, then plays a 3x3 turn-based match against an AI opponent. The core mechanic is similar to tic-tac-toe, but the project includes a full mobile game loop: character selection, AI difficulty, unlockable emojis, rewarded ads, interstitial ads, settings, sound, vibration, popups, and visual polish.

The main technical goal was to avoid a typical UI-heavy Unity prototype. I separated the game rules, presentation, and infrastructure. BoardState and WinChecker handle the rules, AI is implemented with the Strategy pattern, progress and saves are handled by dedicated services, and each scene is assembled through installer/controller classes. This makes the project easier to maintain, extend, and test.

## Full 2-3 minute version

Emoji Battle is my mobile Unity project that I developed into a finished Android game. It is a small but complete puzzle-battle game. The player starts from a Bootstrap scene, moves into the Lobby, chooses an emoji, a color, and an AI difficulty, and then starts a match in the Main scene.

The main mechanic is similar to tic-tac-toe: the player and the AI take turns placing their emoji on a 3x3 board. The game checks horizontal, vertical, and diagonal lines for a win. I expanded this simple mechanic into a full mobile game loop with character selection, AI difficulty, progression, unlockable emojis, rewarded ads, interstitial ads, music and SFX settings, vibration, popups, and visual effects using DOTween and dissolve animations.

The project contains 9 emoji color sets with 87 emojis in each color. Emoji data is stored in ScriptableObject configs, while player progress is saved as JSON through PlayerPrefs. On the first launch, the player gets a small starter set of unlocked emojis. After that, new emojis can be unlocked by winning matches or by watching rewarded ads. Rewards are based on difficulty, so easy, normal, and hard difficulties unlock different emoji ranges.

The most important part of the project for me is the architecture. I focused on separating responsibilities. The board domain logic is independent from the Unity UI. BoardState stores the cell state, WinChecker checks wins and draws, and GameFlow controls turns and exposes events. The UI does not decide who won; it only displays the result. AI behavior is separated into EasyStrategy, NormalStrategy, and HardStrategy. AIStrategyFactory selects the correct strategy based on the selected difficulty, so a new difficulty can be added without rewriting the main game flow.

At the scene level, I used an installer/controller approach. For example, MainInstaller creates BoardState, WinChecker, GameFlow, GameRewardService, GameResultController, and MainController, then injects the scene views into them. This works as a simple composition root. It also allows the project to avoid FindObjectOfType or GameObject.Find in runtime gameplay logic, because dependencies are passed explicitly.

The project also has infrastructure and service systems: GameDataService for saves, AudioService for music and SFX, SettingsService for player settings, InternetService for connection state, AdsService for Unity Ads, PopupService for popup flow, and VibrationService for mobile feedback. Most of these services are created once in the Bootstrap scene and kept alive across scenes using DontDestroyOnLoad.

The main challenges were not only about gameplay. I had to make sure the game worked correctly across scene changes, event subscriptions did not leak, ads did not break the UI, offline cases were handled clearly, saves were stable, and progression remained extendable. I solved these problems with explicit events, Dispose/OnDestroy cleanup, separate ad states, versioned save payloads, and dedicated popup flows for different game results.

From a performance perspective, the project is lightweight. The board is only 3x3, turn logic runs on clicks or after a short AI delay, and there is no heavy gameplay logic running every frame. The emoji list is rebuilt only when the player changes color, not every frame. This is safe for the current Android scope. I also understand what I would improve in a larger version: object pooling for the emoji scroll view, cached component references, and automated tests for BoardState, WinChecker, AI, and GameProgress.

For me, this project is important because it is not just a prototype. It is end-to-end experience: I built gameplay, UI, architecture, saving, mobile services, ads, build settings, and release preparation. It shows me as a Unity/C# developer who thinks not only about making a feature work, but also about lifecycle, maintainability, scalability, and code quality.

## What the player does

1. The player launches the game and sees the Bootstrap/loading screen.
2. The game loads the Lobby scene and initializes the core services.
3. In the lobby, the player chooses an emoji and a color.
4. The player chooses AI difficulty: Easy, Normal, or Hard.
5. The player presses Start and enters the Main scene.
6. The player and the AI take turns on a 3x3 board.
7. After a win, loss, or draw, the game shows the correct result popup.
8. If the player wins, a new emoji can be unlocked depending on progression rules.
9. Rewarded ads provide another way to unlock emojis.
10. Settings allow the player to change name, music, SFX, and vibration.

## My role in the project

I was responsible for the full development cycle of a mobile Unity game:

- designing the gameplay loop;
- implementing the 3x3 board rules;
- implementing AI with multiple difficulty levels;
- creating the emoji selection and unlock systems;
- saving player progress and settings;
- building UI for the lobby, gameplay, settings, and popups;
- integrating sound, music, vibration, and visual effects;
- integrating Unity Ads;
- handling internet connection state;
- preparing Android build settings, privacy policy, and Google Play release materials;
- refactoring the architecture toward SRP and MVC-style separation.

## Architecture in simple terms

The project is split into several layers.

The Domain layer contains the pure game rules: BoardState, WinChecker, WinResult, CellState, AI strategies, EmojiProgress, and RewardRules. These classes are mostly independent from Unity UI.

The Presentation layer handles visuals and user input: BoardView, MainUIView, LobbyView, EmojiScrollView, PopupBase, PopupService, SettingsPopup, and animation components.

The Infrastructure layer handles data and persistence: SavePayload, PlayerProfile, AIProfile, GameProgress, IDataStorage, and PlayerPrefsStorage.

The Services layer handles global game services: AudioService, AdsService, SettingsService, InternetService, and VibrationService.

The App layer handles startup and initial service setup: EntryPointBootstrap, BootstrapController, and BootstrapView.

The key principle is that gameplay rules should not live inside UI components. The UI can show a button, an emoji, or a popup, but it should not own win conditions, progression rules, or AI decisions.

## Key systems

### Core gameplay

BoardState stores the 3x3 board. GameFlow receives a player or AI move, updates the state, fires OnMoveApplied, checks the result through WinChecker, and changes the turn. WinChecker separately detects wins, draws, and the winning line.

Why it is good: the rules are in one clear place and are not mixed with buttons, animations, or scene objects.

### AI

AI is built around the IAIStrategy interface. The project has EasyStrategy, NormalStrategy, and HardStrategy. Different difficulty levels use different probabilities: the AI may try to win, block the player, take the center, take a corner, or make a random move.

Why it is good: AI difficulty can change without modifying GameFlow. GameFlow only knows that a strategy returns a board index.

### Emoji customization

Each emoji color is stored in an EmojiData ScriptableObject. EmojiResolver builds a dictionary by ColorId and returns the correct Sprite by color and index. Player progress stores which emojis are unlocked.

Why it is good: content is separated from code. Emoji sets can be changed in the Unity Inspector.

### Progression and rewards

GameProgress stores EmojiProgress entries, unlock order, progression pointers per difficulty, and the last unlocked emoji. RewardRules defines reward ranges for Easy, Normal, and Hard.

Why it is good: the player gets a clear progression loop, and balance rules are centralized.

### Saving

GameDataService loads and saves SavePayload through PlayerPrefsStorage. Data is serialized as JSON using JsonUtility. SavePayload contains PlayerProfile, AIProfile, GameProgress, SettingsData, first-launch state, and save version.

Why it is good: the save system is simple and suitable for a small mobile game, while SaveVersion gives room for future migrations.

### Popups

PopupService manages the current popup, overlay, and scene context. PopupBase handles show/hide animation, CanvasGroup state, sound, and vibration. ResultPopup adds a Closed event so the match can restart after the result popup closes.

Why it is good: popups share a common lifecycle, while concrete popups only own their specific content.

### Audio, vibration, and settings

AudioService plays playlist-based music and SFX through SoundDefinition. SettingsService saves music, SFX, volume, vibration, and player name. VibrationService provides mobile feedback.

Why it is good: UI does not work directly with AudioSource or PlayerPrefs. It uses services.

### Ads and internet state

AdsService integrates Unity Ads, rewarded ads, and interstitial ads. It stores RewardedState values: Offline, Initializing, Loading, Ready, Showing, and Failed. InternetService checks Application.internetReachability and broadcasts connection changes.

Why it is good: the UI can show loading, connecting, or offline states, and the player gets clear feedback if ads or internet are unavailable.

## Problems and how I solved them

### Problem 1: a simple game can easily become UI spaghetti

If all logic is written inside button MonoBehaviours, the project quickly becomes hard to maintain. UI starts owning rules, AI, saves, and popups.

Solution: I split the project into Domain, Presentation, Infrastructure, Services, and App. GameFlow controls turns, BoardState stores state, WinChecker checks the result, and the UI only displays changes.

What it shows about me: I understand SRP and try to build maintainable architecture even in small projects.

### Problem 2: AI needed to feel different across difficulties

A purely random AI is too weak, while a perfect AI can make a small game feel boring.

Solution: I used the Strategy pattern. Easy, Normal, and Hard use different probabilities for smart actions: winning, blocking, taking the center, taking corners, or making random moves. This creates different difficulty levels while keeping some unpredictability.

What it shows about me: I can choose a solution that fits both code architecture and gameplay feel.

### Problem 3: many emojis needed a clear progress model

The project has 9 colors with 87 emojis each. Without a structured model, unlock state, sorting, and selected characters could become error-prone.

Solution: I moved emoji sets into EmojiData ScriptableObjects and stored progress through EmojiProgress and GameProgress. EmojiResolver separates Sprite access from UI. Unlocking works through ColorId and EmojiId.

What it shows about me: I know how to separate content, data, and presentation.

### Problem 4: rewards needed to depend on difficulty

If rewards are completely random, the progression loop can feel unclear.

Solution: RewardRules defines ranges for Easy, Normal, and Hard. GameRewardService decides whether a new emoji can be unlocked, based on winner, difficulty, internet state, and all-unlocked state.

What it shows about me: I can design code and progression rules together.

### Problem 5: services needed to survive scene changes

Audio, ads, popups, internet checks, and vibration are needed across multiple scenes. If they are recreated without control, duplicates and bugs appear.

Solution: EntryPointBootstrap creates services once. Services use DontDestroyOnLoad and singleton guards. Each scene passes a new popup context to PopupService through SetContext.

What it shows about me: I understand Unity lifecycle and scene transition issues.

### Problem 6: offline and ad states should not break UX

Rewarded ads depend on network state and Unity Ads readiness. If the UI does not know the ad state, the player may press a button and get no result.

Solution: AdsService stores an explicit rewarded ad state. LobbyController converts it into an AdsUiModel, and LobbyView displays button alpha, loading state, or connecting state. If there is no internet, the game shows a NoInternet popup.

What it shows about me: I think about real mobile UX, not only the happy path.

### Problem 7: event subscriptions can leak across scenes

In Unity, it is easy to forget to unsubscribe from events, especially when DontDestroyOnLoad services exist.

Solution: controllers implement Dispose, MonoBehaviours unsubscribe in OnDestroy, popups remove listener callbacks, and services unsubscribe from static events.

What it shows about me: I pay attention to lifecycle and memory leaks.

### Problem 8: the game needed to feel alive but stay lightweight

A simple grid game can feel visually flat.

Solution: I added neon-style UI, DOTween popup animations, dissolve animations for emojis, win line animation, particles, SFX, a music playlist, and vibration feedback. At the same time, the gameplay logic stays lightweight, without heavy physics or repeated runtime object searches.

What it shows about me: I can connect technical architecture with game feel.

## Performance and memory

The project is lightweight for Android: the board is small, turn logic runs only on clicks or after an AI delay, and there is no heavy gameplay logic running in Update. Dependencies are mostly passed through SerializeField or installer classes instead of being found through runtime searches.

What is already good:

- no GameObject.Find or FindObjectOfType in runtime gameplay logic;
- core gameplay does not depend on heavy Unity objects;
- EmojiResolver uses a Dictionary for lookup by ColorId;
- event subscriptions are cleaned up in Destroy/Dispose;
- DOTween tweens are killed in OnDestroy/OnDisable;
- services are created once and guarded against duplicates.

What can be improved:

- EmojiScrollView currently destroys and recreates buttons when the color changes. It is acceptable at the current scale, but pooling would be better for heavier UI.
- BoardState.Data returns a cloned array. For a 3x3 board it is fine, but a larger game should avoid extra copies or expose a readonly snapshot.
- AI strategies allocate List<int> while calculating moves. For 3x3 this is safe, but frequent mobile gameplay systems should reuse buffers.
- BoardView calls TryGetComponent during move and reset. It is not critical for 9 buttons, but DissolveMain references could be cached in Awake.
- Automated tests would be useful for BoardState, WinChecker, GameProgress, and AI strategies.

## What I would improve in the next version

1. Add Assembly Definitions for Domain, Presentation, Services, and Infrastructure.
2. Add EditMode tests for board logic, win/draw detection, AI, and progression.
3. Use pooling for the dynamic emoji scroll list.
4. Cache DissolveMain and TMP_Text references where GetComponentInChildren is currently used.
5. Add migration logic for future SavePayload versions.
6. Make branding fully consistent: Emoji Battle or Emoji Duels.
7. Add gameplay funnel analytics: match started, win, defeat, rewarded viewed, emoji unlocked.
8. Improve AI balance with a minimax mode for hard difficulty or adaptive difficulty.
9. Improve accessibility with better contrast, reduced motion option, and larger buttons for small screens.

## How to present myself through this project

I can say that this project represents me as a Unity/C# developer who can finish a game, not just prototype a mechanic. I built the full mobile loop: loading, lobby, character selection, match flow, AI, win/loss/draw result handling, rewards, saves, sound, vibration, ads, and Android release preparation.

It also shows that I care about architecture. I separate data, game logic, and presentation. I try to avoid god objects and hidden dependencies. I understand Unity lifecycle, event subscriptions, scene changes, and mobile performance. For me, it is important that a project works, but also that it remains maintainable.

## Interview answers in English

### Question: Tell me about your Emoji Battle project

Emoji Battle is a mobile puzzle-battle game built in Unity 6 for Android. It is based on a 3x3 mechanic similar to tic-tac-toe, but I expanded it with emoji customization, AI opponents, a progression loop, rewarded ads, settings, sound, vibration, and visual effects. I implemented the full cycle: gameplay logic, UI, saves, AI, rewards, ads integration, and release preparation.

### Question: What was the hardest part?

The hardest part was not the 3x3 board itself, but turning a simple mechanic into a complete mobile product. I had to separate UI from game logic, build a clear progression system, save player data, handle ads and internet state, and avoid messy architecture. I solved it by splitting the project into layers, using an installer/controller approach, dedicated services, and event-based communication.

### Question: How is the AI built?

The AI is built with the Strategy pattern. There is one IAIStrategy interface and three implementations: Easy, Normal, and Hard. Each strategy receives the current board state and returns a move index. Easy is more random, Normal blocks and wins more often, and Hard almost always looks for a winning move and often blocks the player. GameFlow does not know the AI details, so difficulty can change independently.

### Question: How did you handle saving?

I created GameDataService, which stores a SavePayload object. SavePayload contains the player profile, AI profile, emoji progress, settings, and save version. The data is serialized to JSON and stored through PlayerPrefs. For a small mobile game, this is a simple and practical solution, and SaveVersion gives room for future migrations.

### Question: What did you do for performance?

I avoided runtime object searches in gameplay logic, kept heavy logic out of Update, made core gameplay independent from Unity UI, and used explicit references through SerializeField and installer classes. Since the board is only 3x3, the main operations are very cheap. I also know where I would improve it: pooling for the emoji scroll list, cached component references, and unit tests.

### Question: What would you improve now?

I would add automated tests for the domain logic, use pooling for the dynamic emoji list, add Assembly Definitions for clearer module boundaries, improve save migrations, and make the branding fully consistent. I would also improve AI balance, possibly with minimax for hard mode or adaptive difficulty.

---

# Useful Vocabulary

## Project description

- мобильная игра - mobile game
- опубликованная игра - shipped game / released game
- игровой цикл - gameplay loop
- пошаговая игра - turn-based game
- соперник с искусственным интеллектом - AI opponent
- выбор персонажа - character selection
- прогрессия игрока - player progression
- разблокировка наград - reward unlocking
- настройки игрока - player settings
- подготовка к релизу - release preparation

## Architecture

- разделение ответственности - separation of responsibilities
- принцип единственной ответственности - Single Responsibility Principle
- игровая логика - gameplay logic / game rules
- представление / UI - presentation layer
- инфраструктура - infrastructure layer
- сервисы - services
- точка сборки зависимостей - composition root
- явные зависимости - explicit dependencies
- скрытые зависимости - hidden dependencies
- поддерживаемая архитектура - maintainable architecture
- расширяемая система - extensible system

## Unity and performance

- смена сцен - scene transitions
- жизненный цикл Unity - Unity lifecycle
- подписки на события - event subscriptions
- утечка памяти - memory leak
- лишние аллокации - unnecessary allocations
- кешировать ссылки - cache references
- объектный пул - object pooling
- визуальные эффекты - visual effects
- вибрация - vibration / haptic feedback
- сохранение через PlayerPrefs - saving through PlayerPrefs

## Good English phrases to memorize

- I built this project as a complete mobile game, not just a prototype.
- The core mechanic is simple, but I expanded it into a full mobile gameplay loop.
- I separated gameplay rules from UI to keep the project maintainable.
- I used the Strategy pattern for AI difficulty.
- I used ScriptableObjects to keep content configuration separate from code.
- I handled scene lifecycle carefully to avoid duplicate services and event leaks.
- I integrated rewarded ads and handled offline cases with clear UI feedback.
- The project taught me how to think about gameplay, architecture, mobile UX, and release preparation together.
- If I continued the project, I would add automated tests, pooling, stronger save migrations, and more advanced AI.

---

# Daily Practice Script

## Russian daily version

Emoji Battle - это мой мобильный Unity-проект для Android. Это puzzle-battle игра, похожая на tic-tac-toe, но с эмодзи-персонажами, выбором цвета, AI-соперниками, прогрессией и разблокировкой новых эмодзи.

Я реализовал полный игровой цикл: загрузка, лобби, выбор персонажа, выбор сложности, матч, проверка победы или ничьей, попап результата, награды, сохранения, настройки, звук, вибрация и реклама.

Технически я разделил проект на слои. Domain отвечает за правила игры, Presentation за UI, Infrastructure за данные и сохранения, Services за глобальные сервисы, а App за запуск проекта. Я старался соблюдать SRP, не смешивать UI с игровой логикой и делать зависимости явными.

Самые важные решения: AI через Strategy pattern, эмодзи через ScriptableObjects, прогресс через GameProgress, сохранения через JSON/PlayerPrefs, а сцены через installer/controller подход. Главные сложности были в том, чтобы превратить простую механику в законченный мобильный продукт и не получить хаотичную архитектуру.

Этот проект показывает, что я умею делать не только прототип, но и полный игровой продукт: gameplay, UI, architecture, saves, ads, mobile services and release preparation.

## English daily version

Emoji Battle is my mobile Unity project for Android. It is a puzzle-battle game inspired by tic-tac-toe, but expanded with emoji characters, color selection, AI opponents, progression, and unlockable emojis.

I implemented the full gameplay loop: loading, lobby, character selection, difficulty selection, match flow, win or draw detection, result popups, rewards, saving, settings, sound, vibration, and ads.

Technically, I split the project into layers. Domain handles the game rules, Presentation handles UI, Infrastructure handles data and saving, Services handle global systems, and App handles startup. I focused on SRP, keeping gameplay logic separate from UI, and making dependencies explicit.

The most important decisions were using the Strategy pattern for AI, ScriptableObjects for emoji content, GameProgress for unlock state, JSON/PlayerPrefs for saves, and an installer/controller approach for scenes. The main challenge was turning a simple mechanic into a complete mobile product without creating messy architecture.

This project shows that I can build more than a prototype. I can work on gameplay, UI, architecture, saves, ads, mobile services, and release preparation as one complete product.
