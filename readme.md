
# Problem 

When a CollectionView is nested inside a parent that has a TapGestureRecognizer, the CollectionView's items cannot be
selected unless the user presses the item for at least a few seconds (even then sometimes it doesn't work). The parent with 
the TapGestureRecognizer also doesn't have to be a direct parent for the issue to arise, I've just structured the XAML this way for simplicity.

I've only observed this bug on iOS; Android works fine. I haven't tested other platforms.

Another problem that can be seen is that the CollectionView's initial selection (set programmatically in the 
code-behind's constructor) doesn't appear to be selected. This bug isn't the focus of this reproduction, but it's 
somewhat relevant given that it's also an iOS-specific problem related to the CollectionView, so it might end up
helping in some way. This separate (although perhaps related) bug already has an open [issue](https://github.com/dotnet/maui/issues/18933).

There are other CollectionView bugs that occur on iOS but not Android (e.g. this [one](https://github.com/dotnet/maui/issues/23435)) but I'm less sure if these are related to this bug.

# Expected Behaviour

The TapGestureRecognizer of the CollectionView's parent shouldn't be called and the CollectionView's items should be selected as intended. This is the behaviour that occurs on Android and is also the behaviour that's observed when a normal Button is clicked on iOS.

# How To Replicate

1. Try to click one of the CollectionView's items (i.e. either 'Hello' or 'World'). You will fine that the container's TapGestureRecognizer is called, but the CollectionView's selection doesn't occur.
2. Press down on one of the CollectionView's items for a few seconds. You might find that the selection occurs (and that the parent's TapGestureRecognizer isn't called).
3. Click the "Hello World" button beneath the CollectionView. You should observe that its command is called without issue, which contrasts with the CollectionView's items.
4. Remove the TapGestureRecognizer from the CollectionView's parent.
5. Click one of the CollectionView's items again. You should notice that the selection works (without having to press down for a few seconds).

# Workaround

I haven't been able to find any workarounds.