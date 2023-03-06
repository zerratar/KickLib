First the connection

WebSocketeb1d5f283081a78b932c?protocol=7&client=js&version=7.4.0&flash=false	
Finish: 4.2 min
DOMContentLoaded: 643 ms
Request URL: wss://ws-us2.pusher.com/app/eb1d5f283081a78b932c?protocol=7&client=js&version=7.4.0&flash=false
Request Method: GET
Status Code: 101 Switching Protocols

Response Headers
Connection: upgrade
Date: Mon, 06 Mar 2023 06:40:56 GMT
Sec-WebSocket-Accept: <Base64 Encoded Key>
Upgrade: websocket

Request Headers
Accept-Encoding: gzip, deflate, br
Accept-Language: en,sv;q=0.9,en-US;q=0.8
Cache-Control: no-cache
Connection: Upgrade
Host: ws-us2.pusher.com
Origin: https://kick.com
Pragma: no-cache
Sec-WebSocket-Extensions: permessage-deflate; client_max_window_bits
Sec-WebSocket-Key: <Base64 Encoded Key>
Sec-WebSocket-Version: 13
Upgrade: websocket
User-Agent: Mozil



Messages:
  1. Received
    {"event":"pusher:connection_established","data":"{\"socket_id\":\"1234.56788\",\"activity_timeout\":120}"}

  2. Sent
    {"event":"pusher:subscribe","data":{"auth":"0000000000000000000000000000000:11111111111111111111111111111","channel":"private-userfeed.123456"}}

  3. Received
    {"event":"pusher_internal:subscription_succeeded","data":"{}","channel":"private-userfeed.123456"}

  4. Sent  (Auth changed here, but channel's id was same)
    {"event":"pusher:subscribe","data":{"auth":"0000000000000000000000000000000:22222222222222222222222222222","channel":"private-App.User.123456"}}

  5. Received
    {"event":"pusher_internal:subscription_succeeded","data":"{}","channel":"private-App.User.123456"}

  6. Sent     (Channel id is different on all messages sent here, Auth was changed one more time, first part was always the same)
    {"event":"pusher:subscribe","data":{"auth":"","channel":"channel.1234165"}}  
    {"event":"pusher:subscribe","data":{"auth":"","channel":"chatrooms.5432132"}}
    {"event":"pusher:subscribe","data":{"auth":"0000000000000000000000000000000:33333333333333333333333333333","channel":"private-livestream.3456789"}}

  7. Received
    {"event":"pusher_internal:subscription_succeeded","data":"{}","channel":"channel.1234165"}
    {"event":"pusher_internal:subscription_succeeded","data":"{}","channel":"chatrooms.5432132"}
    {"event":"pusher_internal:subscription_succeeded","data":"{}","channel":"private-livestream.3456789"}

After that, there was a continues stream of chat messages

{"event":"App\\Events\\ChatMessageSentEvent","data":"{\"message\":{\"id\":\"cbe30b46-547a-4029-bc5c-d536c9296bf9\",\"message\":\"[emote:113773:L][emote:113773:L][emote:113773:L][emote:113773:L][emote:113773:L]ove you haydeeen\",\"type\":\"\",\"replied_to\":null,\"is_info\":null,\"link_preview\":null,\"chatroom_id\":\"5432132\",\"role\":null,\"created_at\":1678084857,\"action\":null,\"optional_message\":null,\"months_subscribed\":1,\"subscriptions_count\":null,\"giftedUsers\":null},\"user\":{\"id\":1370709,\"username\":\"indigogo\",\"role\":null,\"isSuperAdmin\":false,\"profile_thumb\":null,\"verified\":false,\"follower_badges\":[],\"is_subscribed\":true,\"is_founder\":false,\"months_subscribed\":1,\"quantity_gifted\":0}}","channel":"chatrooms.58566"}

And followers update

{"event":"App\\Events\\FollowersUpdated","data":"{\"followersCount\":348,\"channel_id\":1234165,\"username\":null,\"created_at\":1678084970,\"followed\":true}","channel":"channel.1234165"}


====================================================================

  Different areas of a streamer has different IDs, so the channel has an ID, their private userfeed has an ID, their user has an ID, live stream has an ID, chat room has an ID, list goes long.
  How these different IDs are fetched needs to be investigated.
  What the Auth: A:B is and what the Sec-WebSocket-Key is.
  
  Their servies does use oauth2, and uses an authporization bearer token for their apis.

 Before/while all these websocket requests are being made, the following endpoints are accessed:

 1. https://kick.com/api/v1/user
 2. https://kick.com/stream/featured-livestreams/en
 3. https://kick.com/api/v1/categories
 4. wss://ws-us2.pusher.com/app/eb1d5f283081a78b932c?protocol=7&client=js&version=7.4.0&flash=false
 5. https://kick.com/api/v1/channels/followed
 6. https://kick.com/broadcasting/auth
 7. https://kick.com/broadcasting/auth
 8. https://kick.com/kick-token-provider
 9. https://kick.com/api/v1/channels/<channel name>
 10. https://kick.com/cdn-cgi/challenge-platform/h/g/cv/result/<result>
 11. https://kick.com/broadcasting/auth
 12. https://kick.com/api/v2/channels/<channel name>/me
 13. https://kick.com/api/v1/channels/<channel name>/links
 14. https://kick.com/api/v2/channels/<channel name>/leaderboards
 15. https://kick.com/emotes/<channel name>

  Then it looks like only stream data is being sent.