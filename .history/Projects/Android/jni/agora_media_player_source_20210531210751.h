#pragma once

namespace agora {
    namespace rtc {
        class AgoraMediaPlayerSource : public IMediaPlayerSourceObserver {
            public: 
                AgoraMediaPlayerSource() = default;
                virtual ~AgoraMediaPlayerSource();
        };
    }
}