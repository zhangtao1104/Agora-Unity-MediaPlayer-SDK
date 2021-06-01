LOCAL_PATH := $(call my-dir)

include $(CLEAR_VARS)
LOCAL_MODULE := agora-rtc
LOCAL_SRC_FILES := ../prebuilt/$(TARGET_ARCH_ABI)/libagora-rtc-sdk-jni.so 
include $(PREBUILT_SHARED_LIBRARY)

include $(CLEAR_VARS)
LOCAL_MODULE := agora-ffmpeg
LOCAL_SRC_FILES := ../prebuilt/$(TARGET_ARCH_ABI)/libagora-ffmpeg.so 
include $(PREBUILT_SHARED_LIBRARY)

include $(CLEAR_VARS)   
LOCAL_MODULE_CLASS := SHARED_LIBRARIES
LOCAL_MODULE       := libmediaPlayerCWrapper
LOCAL_MODULE_TAGS  := optional
LOCAL_SRC_FILES := media_player_c_api.cpp \
				agora_media_player_source.cpp
		
LOCAL_C_INCLUDES := ../prebuilt/high_level_api/include/
LOCAL_LDLIBS := -llog -landroid -lEGL -lGLESv2
LOCAL_SHARED_LIBRARIES := agora-rtc
include $(BUILD_SHARED_LIBRARY)