using strange.extensions.signal.impl;

/* all signal classes created here */
public class AppStartSignal : Signal { }
public class LoadSceneSignal : Signal<string> { }
public class CallWebServiceSignal : Signal<string[]> { }
public class FulfillWebServiceRequestSignal : Signal<bool> { }
public class CallStartCounterSignal : Signal<float> { }
public class MysteryStartSignal : Signal { }