namespace agora {
    namespace mediaPlayer {
        internal class IMediaPlayerNative {
            #region
            #if UNITY_STANDALONE_WIN || UNITY_EDITOR
                    public const string MyLibName = "mediaPlayerCWrapper";
            #else

            #if UNITY_IPHONE
                    public const string MyLibName = "__Internal";
            #else
                    public const string MyLibName = "mediaPlayerCWrapper";
            #endif
            #endif
            #endregion
        }
    }
}