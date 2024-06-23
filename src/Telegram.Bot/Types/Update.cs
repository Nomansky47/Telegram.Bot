﻿namespace Telegram.Bot.Types;

/// <summary>This <a href="https://core.telegram.org/bots/api#available-types">object</a> represents an incoming update.<br/>At most <b>one</b> of the optional parameters can be present in any given update.</summary>
public partial class Update
{
    /// <summary>The update's unique identifier. Update identifiers start from a certain positive number and increase sequentially. This identifier becomes especially handy if you're using <see cref="TelegramBotClientExtensions.SetWebhookAsync">webhooks</see>, since it allows you to ignore repeated updates or to restore the correct update sequence, should they get out of order. If there are no new updates for at least a week, then identifier of the next update will be chosen randomly instead of sequentially.</summary>
    [JsonPropertyName("update_id")]
    [JsonIgnore(Condition = JsonIgnoreCondition.Never)]
    public int Id { get; set; }

    /// <summary><em>Optional</em>. New incoming message of any kind - text, photo, sticker, etc.</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Message? Message { get; set; }

    /// <summary><em>Optional</em>. New version of a message that is known to the bot and was edited. This update may at times be triggered by changes to message fields that are either unavailable or not actively used by your bot.</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Message? EditedMessage { get; set; }

    /// <summary><em>Optional</em>. New incoming channel post of any kind - text, photo, sticker, etc.</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Message? ChannelPost { get; set; }

    /// <summary><em>Optional</em>. New version of a channel post that is known to the bot and was edited. This update may at times be triggered by changes to message fields that are either unavailable or not actively used by your bot.</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Message? EditedChannelPost { get; set; }

    /// <summary><em>Optional</em>. The bot was connected to or disconnected from a business account, or a user edited an existing connection with the bot</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public BusinessConnection? BusinessConnection { get; set; }

    /// <summary><em>Optional</em>. New message from a connected business account</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Message? BusinessMessage { get; set; }

    /// <summary><em>Optional</em>. New version of a message from a connected business account</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Message? EditedBusinessMessage { get; set; }

    /// <summary><em>Optional</em>. Messages were deleted from a connected business account</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public BusinessMessagesDeleted? DeletedBusinessMessages { get; set; }

    /// <summary><em>Optional</em>. A reaction to a message was changed by a user. The bot must be an administrator in the chat and must explicitly specify <c>"<see cref="MessageReaction">MessageReaction</see>"</c> in the list of <em>AllowedUpdates</em> to receive these updates. The update isn't received for reactions set by bots.</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public MessageReactionUpdated? MessageReaction { get; set; }

    /// <summary><em>Optional</em>. Reactions to a message with anonymous reactions were changed. The bot must be an administrator in the chat and must explicitly specify <c>"<see cref="MessageReactionCount">MessageReactionCount</see>"</c> in the list of <em>AllowedUpdates</em> to receive these updates. The updates are grouped and can be sent with delay up to a few minutes.</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public MessageReactionCountUpdated? MessageReactionCount { get; set; }

    /// <summary><em>Optional</em>. New incoming <a href="https://core.telegram.org/bots/api#inline-mode">inline</a> query</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public InlineQuery? InlineQuery { get; set; }

    /// <summary><em>Optional</em>. The result of an <a href="https://core.telegram.org/bots/api#inline-mode">inline</a> query that was chosen by a user and sent to their chat partner. Please see our documentation on the <a href="https://core.telegram.org/bots/inline#collecting-feedback">feedback collecting</a> for details on how to enable these updates for your bot.</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ChosenInlineResult? ChosenInlineResult { get; set; }

    /// <summary><em>Optional</em>. New incoming callback query</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public CallbackQuery? CallbackQuery { get; set; }

    /// <summary><em>Optional</em>. New incoming shipping query. Only for invoices with flexible price</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ShippingQuery? ShippingQuery { get; set; }

    /// <summary><em>Optional</em>. New incoming pre-checkout query. Contains full information about checkout</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public PreCheckoutQuery? PreCheckoutQuery { get; set; }

    /// <summary><em>Optional</em>. New poll state. Bots receive only updates about manually stopped polls and polls, which are sent by the bot</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public Poll? Poll { get; set; }

    /// <summary><em>Optional</em>. A user changed their answer in a non-anonymous poll. Bots receive new votes only in polls that were sent by the bot itself.</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public PollAnswer? PollAnswer { get; set; }

    /// <summary><em>Optional</em>. The bot's chat member status was updated in a chat. For private chats, this update is received only when the bot is blocked or unblocked by the user.</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ChatMemberUpdated? MyChatMember { get; set; }

    /// <summary><em>Optional</em>. A chat member's status was updated in a chat. The bot must be an administrator in the chat and must explicitly specify <c>"<see cref="ChatMember">ChatMember</see>"</c> in the list of <em>AllowedUpdates</em> to receive these updates.</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ChatMemberUpdated? ChatMember { get; set; }

    /// <summary><em>Optional</em>. A request to join the chat has been sent. The bot must have the <em>CanInviteUsers</em> administrator right in the chat to receive these updates.</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ChatJoinRequest? ChatJoinRequest { get; set; }

    /// <summary><em>Optional</em>. A chat boost was added or changed. The bot must be an administrator in the chat to receive these updates.</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ChatBoostUpdated? ChatBoost { get; set; }

    /// <summary><em>Optional</em>. A boost was removed from a chat. The bot must be an administrator in the chat to receive these updates.</summary>
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public ChatBoostRemoved? RemovedChatBoost { get; set; }

    /// <summary>Gets the <see cref="UpdateType">type</see> of the <see cref="Update"/></summary>
    /// <value>The <see cref="UpdateType">type</see> of the <see cref="Update"/></value>
    [JsonIgnore]
    public UpdateType Type => this switch
    {
        { Message: not null }                 => UpdateType.Message,
        { EditedMessage: not null }           => UpdateType.EditedMessage,
        { ChannelPost: not null }             => UpdateType.ChannelPost,
        { EditedChannelPost: not null }       => UpdateType.EditedChannelPost,
        { BusinessConnection: not null }      => UpdateType.BusinessConnection,
        { BusinessMessage: not null }         => UpdateType.BusinessMessage,
        { EditedBusinessMessage: not null }   => UpdateType.EditedBusinessMessage,
        { DeletedBusinessMessages: not null } => UpdateType.DeletedBusinessMessages,
        { MessageReaction: not null }         => UpdateType.MessageReaction,
        { MessageReactionCount: not null }    => UpdateType.MessageReactionCount,
        { InlineQuery: not null }             => UpdateType.InlineQuery,
        { ChosenInlineResult: not null }      => UpdateType.ChosenInlineResult,
        { CallbackQuery: not null }           => UpdateType.CallbackQuery,
        { ShippingQuery: not null }           => UpdateType.ShippingQuery,
        { PreCheckoutQuery: not null }        => UpdateType.PreCheckoutQuery,
        { Poll: not null }                    => UpdateType.Poll,
        { PollAnswer: not null }              => UpdateType.PollAnswer,
        { MyChatMember: not null }            => UpdateType.MyChatMember,
        { ChatMember: not null }              => UpdateType.ChatMember,
        { ChatJoinRequest: not null }         => UpdateType.ChatJoinRequest,
        { ChatBoost: not null }               => UpdateType.ChatBoost,
        { RemovedChatBoost: not null }        => UpdateType.RemovedChatBoost,
        _                                     => UpdateType.Unknown
    };
}
