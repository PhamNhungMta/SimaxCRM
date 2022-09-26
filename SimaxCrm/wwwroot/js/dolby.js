var dolby = {
    variable: {
        conference: null,
        participant: [],
        isMyVideoInit: false,
        isOtherVideoInit: false,
        isMute: false,
        isVideoOff: false,
        signalRUserTemp: {
            callId: null,
            user: null
        },
        signalRUser: {
            callId: null,
            user: null,
            isVideo: true
        }
    },
    resetVideoVariable: function () {
        dolby.variable.isMyVideoInit = false;
        dolby.variable.isOtherVideoInit = false;
        dolby.variable.isMute = false;
        dolby.variable.isVideoOff = true;
        $("#my-video-container").hide();
        $("#other-video-container").hide();
    },

    callNotification: function (data, isVideo) {
        srJs.callInvite(data, isVideo);
    },

    incommigCallPrompt: function (data, callId, isVideo) {
        var callPrompt = "Incomming call from " + JSON.parse(data.Key).Name;
        $("#lblCallMsg").html(callPrompt);
        $("#videoCallModalPrompt").modal('show');

        dolby.variable.signalRUserTemp = {
            user: data,
            callId: callId,
            isVideo: isVideo
        };
    },

    rejectCallPrompt: function (data) {
        $("#videoCallModal").modal('hide');

        var callPrompt = "Call rejected by " + JSON.parse(data.Key).Name;
        $("#lblCallMsgReject").html(callPrompt);
        $("#videoCallModalReject").modal('show');
    },

    acceptCall: function () {
        dolby.variable.signalRUser = {
            user: dolby.variable.signalRUserTemp.user,
            callId: dolby.variable.signalRUserTemp.callId,
            isVideo: dolby.variable.signalRUserTemp.isVideo
        };
        $("#videoCallModalPrompt").modal('hide');
        dolby.variable.isVideoOff = !dolby.variable.signalRUser.isVideo;

        dolby.joinCall(dolby.variable.signalRUser.callId);

        srJs.callAccepted(dolby.variable.signalRUser);
    },

    rejectCall: function () {
        srJs.rejectCall(dolby.variable.signalRUserTemp);
    },

    initSession: function (callbackFunc) {
        ajaxPostCall("/Call/GetCallToken", {}, function (data) {
            dolby.openSession(data.access_token.access_token, data.name, data.userId);
            if (callbackFunc) {
                callbackFunc();
            }
        });
    },

    joinCall: function (appointmentId) {
        $("#videoCallModalPreview").modal('show');
        dolby.join(appointmentId);
        dolby.toggleMicButtons();
        dolby.toggleVideoButtons();
    },

    openSession: function (access_token, name, userId) {

        /* Event handlers */

        // When a video stream is added to the conference
        VoxeetSDK.conference.on('streamAdded', (participant, stream) => {
            dolby.addParticipantNode(participant);
            dolby.addVideoNode(participant, stream);
        });

        VoxeetSDK.conference.on('streamUpdated', (participant, stream) => {
            dolby.addVideoNode(participant, stream);
        });

        // When a video stream is removed from the conference
        VoxeetSDK.conference.on('streamRemoved', (participant, stream) => {
            dolby.removeParticipantNode(participant, stream);
        });

        VoxeetSDK.command.on(
            "received", (participant, message) => {
                if (message == 'CallEnd') {
                    VoxeetSDK.conference.leave();
                    dolby.resetVideoVariable();
                    $("#videoCallModalPreview").modal('hide');
                    $("#videoCallModalEnd").modal('show');
                }
                else {
                    $('video[participantid="' + participant.id + '"]').toggle();
                }
            });



        VoxeetSDK.initializeToken(access_token,
            () => {
                // This callback is called when the token needs to be refreshed. See the next section for details.
            });

        VoxeetSDK.session.open({ name: name, userId: userId });
    },

    join: function (appointmentId) {
        // Default conference parameters
        // See: https://dolby.io/developers/interactivity-apis/client-sdk/reference-javascript/model/conferenceparameters
        let conferenceParams = {
            liveRecording: false,
            rtcpMode: "average", // worst, average, max
            ttl: 0,
            videoCodec: "H264" // H264, VP8
        };

        // See: https://dolby.io/developers/interactivity-apis/client-sdk/reference-javascript/model/conferenceoptions
        let conferenceOptions = {
            alias: appointmentId,
            params: conferenceParams
        };

        // 1. Create a conference room with an alias
        VoxeetSDK.conference.create(conferenceOptions)
            .then((conference) => {
                dolby.variable.conference = conference;

                // See: https://dolby.io/developers/interactivity-apis/client-sdk/reference-javascript/model/joinoptions
                const joinOptions = {
                    constraints: {
                        audio: !dolby.variable.isMute,
                        video: !dolby.variable.isVideoOff
                    },
                    simulcast: false
                };

                // 2. Join the conference
                VoxeetSDK.conference.join(conference, joinOptions)
                    .then((data) => {
                        //conferenceAliasInput.disabled = true;
                        //joinButton.disabled = true;
                        //leaveButton.disabled = false;
                        //startVideoBtn.disabled = false;
                        //startScreenShareBtn.disabled = false;
                        //startRecordingBtn.disabled = false;
                    })
                    .catch((e) => console.log(e));
            })
            .catch((e) => console.log(e));
    },

    addVideoNode: function (participant, stream) {
        //let videoNode = document.getElementById('video-' + participant.id);

        //if (!videoNode) {
        //  videoNode = document.createElement('video');

        //  videoNode.setAttribute('id', 'video-' + participant.id);
        //  videoNode.setAttribute('height', 240);
        //  videoNode.setAttribute('width', 320);
        //  videoNode.style = 'background: gray;';

        //  const videoContainer = document.getElementById('video-container');
        //  videoContainer.appendChild(videoNode);

        //  videoNode.autoplay = 'autoplay';
        //  videoNode.muted = true;
        //}
        //navigator.attachMediaStream(videoNode, stream);

        if (VoxeetSDK.session.participant.id === participant.id) {
            //if (!dolby.variable.isMyVideoInit) {
            let videoNode = document.getElementById('my-video-container');
            if (videoNode) {
                videoNode.setAttribute('height', 240);
                videoNode.setAttribute('width', 320);
                videoNode.setAttribute('participantid', participant.id);
                videoNode.style = 'background: gray;';
                videoNode.autoplay = 'autoplay';
                videoNode.muted = true;
            }
            navigator.attachMediaStream(videoNode, stream);
            dolby.variable.isMyVideoInit = true;
            //}
        } else {
            var obj = dolby.variable.participant.filter(function (i, n) {
                return i.id === participant.id;
            });
            if (obj.length > 0) {
                //if (!dolby.variable.isOtherVideoInit) {
                let videoNode = document.getElementById('other-video-container');
                if (videoNode) {
                    videoNode.setAttribute('height', '100%');
                    videoNode.setAttribute('width', '100%');
                    videoNode.setAttribute('participantid', participant.id);
                    videoNode.style = 'background: gray;';
                    videoNode.autoplay = 'autoplay';
                    videoNode.muted = true;
                }
                navigator.attachMediaStream(videoNode, stream);
                dolby.variable.isOtherVideoInit = true;
                setTimeout(function () {
                    dolby.variable.isOtherVideoInit = false;
                },
                    2000);
                //}
            }
        }
    },

    addParticipantNode: function (participant) {
        // If the participant is the current session user, don't add himself to the list
        if (participant.id === VoxeetSDK.session.participant.id) return;

        var obj = dolby.variable.participant.filter(function (i, n) {
            return i.id === participant.id;
        });

        if (obj.length == 0) {
            dolby.variable.participant.push({ id: participant.id, name: participant.info.name });
        }
    },

    removeParticipantNode: function (participant) {
        // If the participant is the current session user, don't add himself to the list
        //if (participant.id === VoxeetSDK.session.participant.id) return;

        var index = -1;
        var obj = dolby.variable.participant.filter(function (i, n) {
            index = n;
            return i.id === participant.id;
        });
        if (index > -1) {
            dolby.variable.participant.splice(index, 1);
        }
    },

    mute: function () {
        VoxeetSDK.conference.mute(VoxeetSDK.session.participant, VoxeetSDK.session.participant.isMuted);
        let isMuted = VoxeetSDK.conference.toggleMute(VoxeetSDK.session.participant);
        dolby.variable.isMute = isMuted;
        dolby.toggleMicButtons();
    },

    unmute: function () {
        VoxeetSDK.conference.mute(VoxeetSDK.session.participant, VoxeetSDK.session.participant);
        let isMuted = VoxeetSDK.conference.toggleMute(VoxeetSDK.session.participant);
        dolby.variable.isMute = isMuted;
        dolby.toggleMicButtons();
    },

    toggleMicButtons: function () {
        $("#btnMute").hide();
        $("#btnUnMute").hide();
        if (dolby.variable.isMute) {
            $("#btnMute").show();
        } else {
            $("#btnUnMute").show();
        }
    },

    videoOff: function () {
        VoxeetSDK.conference.stopVideo(VoxeetSDK.session.participant, VoxeetSDK.session.participant);
        dolby.variable.isVideoOff = true;
        dolby.toggleVideoButtons();
        dolby.sendCommand("VideoOff");
        $('video[participantid="' + VoxeetSDK.session.participant.id + '"]').hide();
    },

    videoOn: function () {
        VoxeetSDK.conference.startVideo(VoxeetSDK.session.participant, VoxeetSDK.session.participant);
        dolby.variable.isVideoOff = false;
        dolby.toggleVideoButtons();
        dolby.sendCommand("VideoOn");
        $('video[participantid="' + VoxeetSDK.session.participant.id + '"]').show();
    },

    toggleVideoButtons: function () {
        $("#btnVideoOff").hide();
        $("#btnVideoOn").hide();
        if (dolby.variable.isVideoOff) {
            $("#btnVideoOff").show();
        } else {
            $("#btnVideoOn").show();
        }
    },

    sendCommand: function (message) {
        VoxeetSDK.command.send(message);
    },

    endCall: function () {
        dolby.sendCommand("CallEnd");
        VoxeetSDK.conference.leave();
        dolby.resetVideoVariable();
        $("#videoCallModalPreview").modal('hide');
        $("#videoCallModalEnd").modal('show');
    }
}
