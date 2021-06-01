#pragma once

#include <cinttypes>
#if defined(_WIN32)
#define WIN32_LEAN_AND_MEAN
#include <windows.h>
#include <cstdint>
#define AGORA_CALL __cdecl
#define AGORA_STD_CALL __stdcall
#if defined(AGORARTC_EXPORT)
#define AGORA_API extern "C" __declspec(dllexport)
#else
#define AGORA_API extern "C" __declspec(dllimport)
#endif
#define _AGORA_CPP_API

#elif defined(__APPLE__)
#define PRINTF(...) printf(...)
#define AGORA_API __attribute__((visibility("default"))) extern "C"
#define AGORA_CALL
#define _AGORA_CPP_API
#define AGORA_STD_CALL
#elif defined(__ANDROID__) || defined(__linux__)
#define PRINTF(...) __android_log_print(ANDROID_LOG_INFO, "CWrapper", __VA_ARGS__)
#define AGORA_STD_CALL
#if defined(__ANDROID__) && defined(FEATURE_RTM_STANDALONE_SDK)
#define AGORA_API extern "C"
#define _AGORA_CPP_API
#else
#define AGORA_API extern "C" __attribute__((visibility("default")))
#define _AGORA_CPP_API __attribute__((visibility("default")))
#endif
#define AGORA_CALL

#else
#define AGORA_STD_CALL
#define AGORA_API extern "C"
#define AGORA_CALL
#define _AGORA_CPP_API
#endif

typedef void(AGORA_STD_CALL *FUNC_OnPlayerSourceStateChanged)(int state, int ec);
typedef void(AGORA_STD_CALL *FUNC_OnPositionChanged)(int64_t position);
typedef void(AGORA_STD_CALL *FUNC_OnPlayerEvent)(int event, int64_t elapsedTimem, const char* message);
typedef void(AGORA_STD_CALL *FUNC_OnMetaData)(const void* data, int length);
typedef void(AGORA_STD_CALL *FUNC_OnPlayBufferUpdated)(int64_t playCachedBuffer);
typedef void(AGORA_STD_CALL *FUNC_OnPreloadEvent)(const char* src, int event);
typedef void(AGORA_STD_CALL *FUNC_OnCompleted)();
typedef void(AGORA_STD_CALL *FUNC_OnAgoraCDNTokenNeedRenew)();