#!/bin/bash

COMMITNR=`git log --pretty="%h" | head -n 1`
dirty=`[[ $(git diff --shortstat 2> /dev/null | tail -n1) != "" ]] && echo "*"`
if [ "$dirty" == "*" ]; then
    COMMITNR=${COMMITNR}-dirty
fi

EXTRACFLAGS=APP_CFLAGS=-DGIT_SRC_VERSION=${COMMITNR}
# clean
#rm -r libs/ || exit 1
ndk-build -C jni/ clean || exit 1

# create shared library
ndk-build V=1 $EXTRACFLAGS -C jni/ || exit 1


rm -rf bin
mkdir bin || exit 1
cp -r prebuilt/ bin/ || exit 1
cp -r libs/ bin/ || exit 1

echo "------ FINISHED --------"
echo "#cp -r bin/ /Users/Shared/Agora/apps/Unity3D/VideoTexture/Assets/Plugins/Android/libs"
exit 0


