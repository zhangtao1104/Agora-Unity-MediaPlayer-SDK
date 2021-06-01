LOCAL_PATH := $(call my-dir)

include $(CLEAR_VARS)
LOCAL_MODULE := agora-rtc
LOCAL_SRC_FILES := ../prebuilt/$(TARGET_ARCH_ABI)/libagora-rtc-sdk.so
include $(PREBUILT_SHARED_LIBRARY)