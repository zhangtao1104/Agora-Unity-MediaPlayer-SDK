namespace agora
{
namespace mediaPlayer
{
internal class IMediaPlayerNative
{
#region
#if UNITY_STANDALONE_WIN || UNITY_EDITOR
    public const string LibraryName = "mediaPlayerCWrapper";
#else

#if UNITY_IPHONE
    public const string LibraryName = "__Internal";
#else
    public const string LibraryName = "mediaPlayerCWrapper";
#endif
#endif
#endregion

[DllImport(LibraryName, CharSet=CharSet.Ansi)]

}
}
}