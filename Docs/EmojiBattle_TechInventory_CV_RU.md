# Emoji Battle - Tech Inventory for CV

Документ помогает собрать конкретный tech stack, навыки и знания, которые видны по проекту Emoji Battle.  
Формулировки разделены на уровни, чтобы в CV писать честно и уверенно.

## 1. Короткий Tech Stack для CV

Можно использовать как короткую строку в резюме:

Unity 6, C#, Android, UGUI, TextMesh Pro, URP, DOTween, ScriptableObjects, PlayerPrefs/JSON persistence, Unity Ads, mobile UI, event-driven architecture, MVC-style separation, Strategy/Factory patterns, scene bootstrap, gameplay systems, AI opponents, progression/reward systems, Git.

Более аккуратный вариант:

Unity 6, C#, Android mobile game development, UGUI/TMP, URP, DOTween, ScriptableObject-based configs, JSON saves with PlayerPrefs, Unity Ads rewarded/interstitial ads, event-driven gameplay architecture, Strategy/Factory patterns, mobile UI/UX, scene lifecycle management.

## 2. Project Tech Stack по категориям

### Engine and Platform

Уверенно можно писать:

- Unity 6.
- Unity Editor project setup.
- Android game development.
- Mobile-first game UI.
- Android package setup.
- Android build settings.
- Google Play release preparation.
- APK/AAB-oriented project configuration.
- Android keystore usage.
- Custom Gradle templates.

Факты из проекта:

- Unity version: 6000.3.5f2.
- Android package id: com.sd7gamestudio.emojibattle.
- Android version code: 6.
- Game version: 1.0.6.
- Android Min SDK: 25.
- Android target architectures value: 3, обычно это ARMv7 + ARM64 в Unity.
- IL2CPP включен для Android.
- Managed Stripping Level для Android: High.
- Incremental GC включен.
- В проекте есть release keystore.
- В проекте есть privacy-policy.html.
- README указывает Google Play release.

Как писать в CV:

- Built and released an Android mobile game with Unity 6.
- Configured Android build settings, package identifier, versioning, keystore, and release materials.
- Worked with IL2CPP Android builds and Unity mobile player settings.

### Programming Language and C# Skills

Уверенно можно писать:

- C#.
- Object-oriented programming.
- Interfaces.
- Enums.
- Classes.
- Structs and readonly structs.
- Properties.
- Events and delegates.
- Action callbacks.
- IDisposable.
- Extension methods.
- Generics.
- Collections: List, Dictionary, arrays.
- Nullable value types, например int?.
- Exceptions and validation.
- Lambdas and closures for UI callbacks.
- Coroutines.
- Async/await with Task.
- Basic data serialization.

Где это видно:

- IAIStrategy interface.
- WinResult and GameRewardResult readonly structs.
- StorageExtensions generic methods.
- Events in GameFlow, LobbyController, PopupService, SettingsService.
- IDisposable in MainController and LobbyController.
- Coroutines in AdsService, AudioService, AIMoveController, PopupCanvasController, VibrationService.
- async/await in EntryPointBootstrap and BootstrapController.
- Dictionaries in EmojiResolver and GameProgress.

Как писать в CV:

- Strong C# fundamentals: OOP, interfaces, events, generics, collections, coroutines, and async/await.
- Used event-driven communication and IDisposable cleanup to manage Unity object lifecycle.

### Unity Core Knowledge

Уверенно можно писать:

- MonoBehaviour lifecycle.
- Awake, Start, OnEnable, OnDisable, OnDestroy.
- Serialized scene references through SerializeField.
- Prefab-based scene composition.
- Scene loading with SceneManager.
- Async scene loading with LoadSceneAsync.
- DontDestroyOnLoad services.
- RuntimeInitializeOnLoadMethod.
- RequireComponent.
- TryGetComponent/GetComponent in initialization or setup.
- Unity coroutines and WaitForSeconds.
- Unity Random and Time APIs.
- Unity PlayerSettings.

Где это видно:

- EntryPointBootstrap creates persistent services.
- BootstrapController uses SceneManager.LoadSceneAsync.
- GameDataService uses RuntimeInitializeOnLoadMethod.
- AudioService, AdsService, PopupService, InternetService, VibrationService use DontDestroyOnLoad.
- PopupBase and DissolveMain use RequireComponent.

Как писать в CV:

- Experienced with Unity lifecycle, scene management, prefab setup, serialized dependencies, and persistent service initialization.

### Architecture and Code Organization

Уверенно можно писать:

- MVC-style separation.
- Layered project structure.
- Domain/Presentation/Infrastructure/Services/App separation.
- SRP-focused class design.
- Explicit dependency passing.
- Composition root / installer pattern.
- Controller/View separation.
- Event-driven architecture.
- Service layer.
- Lightweight service locator / singleton services.
- Decoupling UI from gameplay logic.
- Data model separation.

Где это видно:

- Domain: BoardState, WinChecker, AI strategies, EmojiProgress, RewardRules.
- Presentation: LobbyView, MainUIView, BoardView, PopupBase, EmojiScrollView.
- Infrastructure: SavePayload, PlayerProfile, AIProfile, GameProgress, PlayerPrefsStorage.
- Services: AudioService, AdsService, SettingsService, InternetService, VibrationService.
- App: EntryPointBootstrap, BootstrapController, BootstrapView.
- MainInstaller and LobbyInstaller act as scene composition roots.

Как писать в CV:

- Refactored gameplay code into a layered architecture with separated domain logic, presentation, infrastructure, and services.
- Built scene-level composition roots to avoid hidden runtime dependencies.

### Design Patterns

Уверенно можно писать:

- Strategy pattern.
- Factory pattern.
- Observer/Event pattern.
- Service Locator / Singleton pattern, with caution.
- Composition Root.
- MVC-style Controller/View.
- Data Transfer Object / Save Payload style.
- ScriptableObject config pattern.

Где это видно:

- IAIStrategy, EasyStrategy, NormalStrategy, HardStrategy.
- AIStrategyFactory.
- GameFlow events: OnMoveApplied, OnTurnChanged, OnGameOver.
- SettingsService static events.
- EntryPointBootstrap/MainInstaller/LobbyInstaller.
- SavePayload.
- EmojiData, SoundDefinition, MusicDefinition.

Как писать в CV:

- Applied Strategy and Factory patterns for AI difficulty.
- Used event-driven communication to decouple gameplay, UI, and services.
- Used ScriptableObjects for data-driven configuration.

### Gameplay Programming

Уверенно можно писать:

- Turn-based gameplay.
- 3x3 board logic.
- Game state management.
- Turn switching.
- Move validation.
- Win/draw detection.
- Result handling.
- Restart/session flow.
- AI move delay.
- Board UI synchronization.
- Reward after match.
- Gameplay-to-UI event flow.

Где это видно:

- BoardState.
- GameFlow.
- TurnState.
- WinChecker.
- GameSession.
- MainController.
- BoardView.
- GameResultController.

Как писать в CV:

- Implemented a complete turn-based match flow with board state, move validation, win/draw detection, AI turns, result popups, and session restart.

### AI Programming

Уверенно можно писать:

- Simple game AI.
- Heuristic AI.
- Difficulty tuning.
- Strategy-based AI architecture.
- AI move selection.
- Randomness/probability-based behavior.
- Blocking and winning move detection.
- Gameplay balancing for easy/normal/hard modes.

Где это видно:

- EasyStrategy.
- NormalStrategy.
- HardStrategy.
- GameLogicHelper.FindWinningMove.
- AIStrategyFactory.
- AIMoveController.
- AIComplexityController/View.

Как писать в CV:

- Built heuristic AI opponents with Easy, Normal, and Hard strategies using Strategy/Factory patterns.
- Tuned AI behavior through probability-based decision making for win, block, center, corner, and random moves.

Не писать как сильный навык:

- Minimax AI.
- Machine learning AI.
- Behavior trees.
- NavMesh AI.

Этого в проекте нет.

### Progression and Reward Systems

Уверенно можно писать:

- Unlockable content system.
- Reward rules by difficulty.
- Progression state.
- First-launch initialization.
- Rewarded-ad unlock flow.
- All-unlocked handling.
- Difficulty-specific progression ranges.
- Sorting unlocked/locked content for UI.

Где это видно:

- GameProgress.
- EmojiProgress.
- RewardRules.
- GameRewardService.
- LobbyInstaller.InitProgress.
- VictoryPopup and RewardedPopup preview last unlocked emoji.

Как писать в CV:

- Designed and implemented an emoji unlock progression system with difficulty-based reward ranges and rewarded-ad unlock flow.

### Data and Persistence

Уверенно можно писать:

- PlayerPrefs.
- JSON serialization with JsonUtility.
- Save payload design.
- Player profile persistence.
- AI profile persistence.
- Settings persistence.
- Progress persistence.
- Save version field.
- Storage abstraction.

Где это видно:

- GameDataService.
- IDataStorage.
- PlayerPrefsStorage.
- StorageExtensions.
- SavePayload.
- PlayerProfile.
- AIProfile.
- GameProgress.
- SettingsData.

Как писать в CV:

- Implemented JSON-based save/load system on top of PlayerPrefs with player profile, AI profile, settings, and progression data.

Что не писать как использованное:

- SQLite.
- Cloud Save.
- Firebase.
- PlayFab.
- Addressables save migration.

Этого в проекте нет.

### UI and UX

Уверенно можно писать:

- Unity UGUI.
- TextMesh Pro.
- Buttons.
- Images.
- Sliders.
- Scroll views.
- InputField/TMP_InputField.
- CanvasGroup.
- Popup UI.
- Overlay handling.
- Settings UI.
- Mobile portrait UI.
- Dynamic UI list generation.
- Locked/unlocked UI state.
- Loading screen UI.
- Result popups.
- Ad state UI.
- Basic mobile UX states: loading, connecting, offline, ready.

Где это видно:

- LobbyView.
- MainUIView.
- BoardView.
- EmojiScrollView.
- EmojiButtonView.
- SettingsPopup.
- PopupBase.
- PopupCanvasController.
- BootstrapView.
- AIComplexityView.
- ArrowScrollController.

Как писать в CV:

- Built mobile UI screens with UGUI and TextMesh Pro, including lobby, dynamic emoji selection, settings, match UI, result popups, and ad availability states.

### Animation and Visual Feedback

Уверенно можно писать:

- DOTween.
- DOTween Pro package present.
- UI tweening.
- Popup scale/fade animations.
- Win line fill animation.
- Idle/breathing emoji animation.
- Dissolve visual effects.
- ParticleSystem usage.
- Shader Graph materials for UI/VFX.
- Scene/loading progress animation.

Где это видно:

- PopupBase.
- BootstrapView.
- WinLineView.
- FadeScaleAnimator.
- EmojiIdleAnimation.
- DissolveMain.
- DissolveLobby.
- Shaders folder contains Shader Graph assets: Dissolve, WinLines, BreathOfLight, GridParticle, UI Particle.
- VictoryPopup/RewardedPopup use ParticleSystem.

Как писать в CV:

- Implemented UI feedback and visual polish with DOTween, Shader Graph dissolve effects, particle systems, and animated result popups.

### Audio

Уверенно можно писать:

- AudioSource.
- Music and SFX separation.
- ScriptableObject audio definitions.
- Random clip selection.
- Pitch randomization.
- Volume settings.
- Music playlist/shuffle.
- SFX OneShot playback.

Где это видно:

- AudioService.
- SoundDefinition.
- MusicDefinition.
- AudioSO assets.
- SettingsService audio settings.

Как писать в CV:

- Built an audio service with playlist-based music playback, SFX definitions, volume settings, random clip selection, and pitch variation.

### Mobile Features

Уверенно можно писать:

- Android-specific build setup.
- Mobile vibration/haptic feedback.
- Internet reachability checks.
- Offline UX handling.
- Rewarded ads.
- Interstitial ads.
- App focus/pause handling.
- Mobile-friendly UI flow.
- Privacy policy file for release.

Где это видно:

- VibrationService uses Handheld.Vibrate.
- InternetService uses Application.internetReachability.
- AdsService handles OnApplicationFocus and OnApplicationPause.
- AdsService integrates UnityEngine.Advertisements.
- privacy-policy.html exists.
- sd7games-release.keystore exists.

Как писать в CV:

- Integrated mobile-specific systems such as vibration, internet reachability, Unity Ads, Android build configuration, and release materials.

### Ads and Monetization

Уверенно можно писать:

- Unity Ads.
- Rewarded ads.
- Interstitial ads.
- Ad initialization.
- Ad loading.
- Ad show callbacks.
- Reward callbacks.
- Ad state machine.
- Offline/failed/loading UI states.
- Match-count based interstitial frequency.

Где это видно:

- AdsService.
- LobbyController.OnAdsPressed.
- LobbyController.AdsUiModel.
- GameRewardService.RewardedOpened.

Как писать в CV:

- Integrated Unity Ads with rewarded and interstitial placements, ad loading states, reward callbacks, offline handling, and match-based interstitial frequency.

### Networking / Connectivity

Уверенно можно писать:

- Basic connectivity detection.
- Application.internetReachability.
- Online/offline event broadcasting.
- UI reaction to connectivity state.

Где это видно:

- InternetService.
- LobbyController.OnInternetStateChanged.
- GameRewardService checks hasInternet.
- NoInternet popup flow.

Не писать:

- Multiplayer networking.
- Netcode for GameObjects.
- Client-server architecture.
- REST API integration.

Этого в проекте нет.

### Rendering and Visual Pipeline

Уверенно можно писать:

- Universal Render Pipeline.
- URP 2D project template.
- Shader Graph.
- Materials.
- Particle effects.
- UI shaders.
- Custom dissolve materials.

Где это видно:

- com.unity.render-pipelines.universal 17.3.0.
- Renderer2D and URP assets in Settings.
- Shader Graph files in Assets/Shaders.
- Project template package: universal-2d.

Как писать в CV:

- Used URP and Shader Graph for lightweight mobile visual effects and UI polish.

### Asset and Content Pipeline

Уверенно можно писать:

- Sprite-based content.
- Emoji sprite organization.
- ScriptableObject data assets.
- Prefab organization.
- Audio assets: wav/mp3.
- Material/shader assets.
- Scene screenshots and README documentation.
- Basic branding/release assets.

Факты:

- 9 emoji color folders.
- 87 PNG emojis per color.
- 9 EmojiData ScriptableObjects.
- AudioSO definitions.
- Prefabs for Bootstrap, Lobby, Main, System services, Popups.

Как писать в CV:

- Organized sprite, audio, prefab, ScriptableObject, and shader assets for a complete mobile game project.

### Build, Release, and Project Maintenance

Уверенно можно писать:

- Android build configuration.
- Versioning.
- Package identifier.
- Keystore setup.
- Custom Gradle template usage.
- Privacy policy page.
- README documentation.
- Git repository workflow.
- .gitignore/.gitattributes.
- MIT license file.

Где это видно:

- ProjectSettings.
- Assets/Plugins/Android/mainTemplate.gradle.
- Assets/Plugins/Android/gradleTemplate.properties.
- Assets/Plugins/Android/settingsTemplate.gradle.
- sd7games-release.keystore.
- privacy-policy.html.
- README.md.
- LICENSE.
- .git folder.

Как писать в CV:

- Prepared Android release configuration, project documentation, privacy policy, and Google Play oriented release materials.

### Performance Awareness

Уверенно можно писать:

- Avoiding runtime object searches in gameplay logic.
- Serialized references.
- Basic allocation awareness.
- Event cleanup.
- Tween cleanup.
- Singleton duplicate guards.
- Lightweight gameplay state.
- Avoiding heavy Update logic.
- Managed stripping and incremental GC awareness.

Где это видно:

- No FindObjectOfType/GameObject.Find in project scripts.
- MainInstaller/LobbyInstaller pass dependencies explicitly.
- Dispose/OnDestroy unsubscriptions.
- DOTween.Kill in visual components.
- DontDestroyOnLoad guards.
- Small board state and event-driven moves.

Как писать в CV:

- Applied mobile performance practices: explicit references, no runtime object search in gameplay flow, event cleanup, lightweight state, and controlled scene-service lifecycle.

Что можно улучшить и честно упомянуть на интервью:

- Add pooling for EmojiScrollView.
- Cache DissolveMain references in BoardView.
- Add unit tests for domain logic.
- Reduce small List allocations in AI strategies if the system grows.

### Testing and Debugging

Что можно писать аккуратно:

- Manual gameplay testing.
- Logical scenario testing.
- Unity Editor validation.
- Play mode scenario checks.
- Awareness of Unity Test Framework.

Что не стоит писать как сильный навык из этого проекта:

- Automated unit tests implemented.
- CI/CD pipeline.
- Performance test suite.

Причина:

- Unity Test Framework package is installed, but no actual test files were found in the project scripts/folders during inspection.

### Documentation and Communication

Уверенно можно писать:

- README documentation.
- Project description for portfolio.
- Technical architecture explanation.
- Release notes style documentation.
- Privacy policy page.
- Bilingual project explanation, if you use the prepared docs.

Где это видно:

- README.md.
- privacy-policy.html.
- Docs/EmojiBattle_Project_Story_RU_EN.md.
- This Tech Inventory document.

## 3. Packages and Tools Found in Project

### Direct Unity packages in manifest

Strongly relevant:

- Unity Ads: com.unity.ads 4.16.4.
- Universal Render Pipeline: com.unity.render-pipelines.universal 17.3.0.
- UGUI: com.unity.ugui 2.0.0.
- TextMesh Pro is available through Unity packages/resources.
- Unity Input System: com.unity.inputsystem 1.17.0.
- Unity Test Framework: com.unity.test-framework 1.6.0.
- Unity 2D feature package: com.unity.feature.2d 2.0.2.
- Device Simulator devices: com.unity.device-simulator.devices 1.0.1.

Editor/dev tooling:

- Rider integration: com.unity.ide.rider.
- Visual Studio integration: com.unity.ide.visualstudio.
- Unity Version Control package: com.unity.collab-proxy.

Installed but not core to the actual gameplay code:

- Visual Scripting.
- Timeline.
- Multiplayer Center.
- Many default Unity modules.

Important CV note:

Do not list Multiplayer, Timeline, Visual Scripting, Physics, NavMesh, XR, or UI Toolkit as strong skills from this project unless you used them elsewhere. They are present as packages/modules, but the codebase does not show them as core systems.

### Third-party / external plugins

Used:

- DOTween.
- DOTween Pro.
- DemiLib, as part of Demigiant/DOTween package.

Project folders also include:

- MobileDependencyResolver.
- JMO Assets.

CV wording:

- DOTween for UI animations and visual feedback.
- External Unity asset/plugin integration.

## 4. Concrete Skills You Can Claim From This Project

### Strong claims

These are safe to put in CV:

- Unity C# gameplay programming.
- Android mobile game development.
- Turn-based game systems.
- AI opponent logic with multiple difficulties.
- ScriptableObject-based content configuration.
- UGUI and TextMesh Pro UI development.
- Popup system architecture.
- Save/load system with PlayerPrefs and JSON.
- Unity Ads rewarded/interstitial integration.
- Audio service and settings.
- Mobile vibration and internet state handling.
- DOTween UI animation.
- URP/Shader Graph visual effects.
- Scene bootstrap and persistent services.
- Event-driven architecture.
- Strategy and Factory patterns.
- SRP/MVC-style code organization.
- Git-based project maintenance.
- Google Play release preparation.

### Medium confidence claims

Можно писать, но лучше не преувеличивать:

- Android Gradle customization.
- IL2CPP build configuration.
- Mobile optimization.
- Shader Graph.
- Release pipeline.
- Performance profiling awareness.
- Unity Test Framework awareness.

Почему medium:

- Настройки и файлы есть, но проект не показывает глубокую автоматизацию build pipeline, сложные shader systems или настоящие automated tests.

### Familiarity claims

Лучше формулировать как "familiar with":

- Unity Input System, because package/settings exist, but gameplay input is mainly UGUI button-driven.
- Unity Test Framework, because package exists but tests are not implemented.
- WebGL settings, because project has settings, but main release target is Android.
- Mobile Dependency Resolver, because folder exists, but no deep usage in scripts.

### Do not claim from this project alone

Не стоит писать как опыт из Emoji Battle:

- Multiplayer / Netcode.
- Addressables.
- Firebase.
- PlayFab.
- Cloud Save.
- In-App Purchases.
- Achievements/leaderboards.
- ECS/DOTS.
- Advanced physics.
- NavMesh/pathfinding.
- Cinemachine.
- Timeline-driven cutscenes.
- UI Toolkit production UI.
- Automated CI/CD.
- Automated test coverage.
- Minimax or machine-learning AI.

## 5. CV Bullet Points for Emoji Battle

### Short project bullet

- Built and released Emoji Battle, a Unity 6 Android puzzle-battle game with turn-based 3x3 gameplay, AI opponents, emoji customization, progression, JSON saves, Unity Ads, mobile UI, audio, vibration, and DOTween visual polish.

### Architecture bullet

- Refactored the project into a maintainable MVC-style architecture with separated Domain, Presentation, Infrastructure, Services, and App layers, using explicit dependencies, event-driven communication, and scene-level installers.

### Gameplay/AI bullet

- Implemented complete turn-based gameplay, board state management, win/draw detection, session restart flow, and Easy/Normal/Hard AI using Strategy and Factory patterns.

### Progression bullet

- Designed an unlockable emoji progression system using ScriptableObject content sets, reward rules by AI difficulty, first-launch initialization, and persisted player progress.

### Mobile/services bullet

- Integrated mobile services including Unity Ads rewarded/interstitial placements, internet reachability checks, vibration feedback, audio settings, persistent services, and Android release configuration.

## 6. English CV Tech Section

You can write:

Technical Skills:

- Unity: Unity 6, MonoBehaviour lifecycle, scene management, prefabs, ScriptableObjects, UGUI, TextMesh Pro, URP, Shader Graph, ParticleSystem.
- C#: OOP, interfaces, events/delegates, generics, collections, extension methods, readonly structs, coroutines, async/await, IDisposable.
- Gameplay: turn-based systems, board state, win/draw detection, AI opponents, difficulty balancing, progression and rewards.
- Architecture: SRP, MVC-style separation, event-driven architecture, Strategy/Factory patterns, composition root, service layer.
- Mobile: Android builds, IL2CPP, PlayerSettings, keystore, vibration, internet reachability, mobile UI/UX.
- Services: JSON/PlayerPrefs saves, Unity Ads rewarded/interstitial ads, audio/music systems, settings persistence.
- Tools: Git, Rider/Visual Studio, DOTween, Unity Package Manager, Google Play release preparation.

## 7. Russian CV Tech Section

Можно написать:

Технические навыки:

- Unity: Unity 6, жизненный цикл MonoBehaviour, сцены, префабы, ScriptableObjects, UGUI, TextMesh Pro, URP, Shader Graph, ParticleSystem.
- C#: ООП, интерфейсы, события/delegates, generics, коллекции, extension methods, readonly structs, coroutines, async/await, IDisposable.
- Gameplay: пошаговые системы, board state, проверка победы/ничьей, AI-соперники, баланс сложности, прогрессия и награды.
- Архитектура: SRP, MVC-style separation, event-driven architecture, Strategy/Factory, composition root, service layer.
- Mobile: Android builds, IL2CPP, PlayerSettings, keystore, vibration, internet reachability, mobile UI/UX.
- Services: JSON/PlayerPrefs saves, Unity Ads rewarded/interstitial, audio/music systems, settings persistence.
- Инструменты: Git, Rider/Visual Studio, DOTween, Unity Package Manager, подготовка Google Play release.

## 8. What This Project Says About You As A Developer

На русском:

Этот проект показывает, что я умею не только делать отдельную механику, но и собирать полный мобильный игровой продукт. Я умею проектировать gameplay loop, разделять UI и игровую логику, работать с AI, прогрессией, сохранениями, рекламой, настройками, звуком, мобильными сервисами и Android-релизом. Я понимаю Unity lifecycle, event subscriptions, scene transitions и mobile performance constraints.

На английском:

This project shows that I can build more than an isolated mechanic. I can deliver a complete mobile game product, including gameplay loop, UI, AI, progression, saving, ads, settings, audio, mobile services, and Android release preparation. I understand Unity lifecycle, event subscriptions, scene transitions, and mobile performance constraints.

## 9. Personal Skill Map

### Ты уже можешь позиционировать себя как

- Junior+/Middle-leaning Unity Developer по gameplay/mobile направлению, если хорошо объясняешь проект.
- Unity/C# Gameplay Programmer with mobile release experience.
- Unity Developer focused on clean gameplay architecture and mobile UI.

### Самые сильные стороны из этого проекта

- Умение довести проект до релиза.
- Понимание Unity lifecycle.
- Разделение gameplay logic и UI.
- AI через паттерны.
- Progression/reward systems.
- Mobile services: ads, vibration, internet state.
- Практическое применение SRP.
- Способность рефакторить проект в поддерживаемую структуру.

### Что подтянуть, чтобы CV стало сильнее

- Написать automated tests для Domain layer.
- Добавить object pooling для динамических UI элементов.
- Сделать asmdef по слоям.
- Добавить простой CI build или хотя бы documented build process.
- Добавить profiler screenshots/notes.
- Привести branding к одному названию.
- Добавить clean architecture diagram в README.
- Добавить English demo video или GIF.

## 10. One-Line Identity For CV/Profile

Русский:

Unity/C# разработчик, который умеет создавать мобильные gameplay-системы, строить чистую архитектуру, работать с UI, AI, прогрессией, сохранениями, рекламой и доводить игру до Android-релиза.

English:

Unity/C# developer focused on mobile gameplay systems, clean architecture, UI, AI, progression, persistence, ads integration, and Android release delivery.
