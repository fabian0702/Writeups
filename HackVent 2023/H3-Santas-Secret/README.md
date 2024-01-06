# [HV23.H3] Santas's Secret
## Description

## Solution
When looking at the sourcecode of the webpage of day 20, you can find that there is actually a faster speed which is possible.
```js
    function startAnimation(speed) {
        $("#conveyor-belt")[0].setCurrentTime(0);
        $("#signal .signal-color").attr("fill", "#198754");

        let candySpeed = 10;
        let wheelSpeed = 5;
        if (speed === 1) {
            candySpeed = 5;
            wheelSpeed = 3;
        } else if (speed === 2) {
            candySpeed = 2;
            wheelSpeed = 1;
        }
        for (let i = 0; i <= 10; i++) {
            $("#candy" + i + " animatemotion").attr("begin", candySpeed/10*i);
            $("#candy" + i + " animatemotion").attr("dur", candySpeed);
        }
        $("#wheel-left animateTransform").attr("begin", 0);
        $("#wheel-left animateTransform").attr("dur", wheelSpeed);
        $("#wheel-right animateTransform").attr("begin", 0);
        $("#wheel-right animateTransform").attr("dur", wheelSpeed);
        console.log("done");
    }
```
This speed is given by the product type from the given licence key.
```js
    function license(data) {
        $("#licenseKey").val(data.licenseKey);
        $("#flag").text(data.flag);
        if (!data.isValid) {
            $("#statusBar").text("License is invalid");
            stopAnimation();
            return;
        }

        if (data.isExpired) {
            $("#statusBar").text("License is expired at " + data.expirationDate);
            stopAnimation();
            return;
        }

        if (!data.isExpired) {
            $("#statusBar").text("License is valid until " + data.expirationDate);
            startAnimation(data.productType);
            return;
        }
    }
```
When having a closer look at the contents of the licence key struct, there is a Product type PREMIUM which coinicentally also has the value 2. And indeed if we find a key with this premium, you get the hidden flag.

Flag: **HV23{sup3r-h1dd3n-k3yg3n-fl4g}**