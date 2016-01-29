settings = {
    -- INPUT
    keys = {
        up =    { "up",    "w" },
        down =  { "down",  "s" },
        left =  { "left",  "a" },
        right = { "right", "d" },
    },

    gamepad = {
        up =    "dpup",
        down =  "dpdown",
        left =  "dpleft",
        right = "dpright",
    },

    shortcuts = {
        quit = {
            key = "escape",
            func = function ()
                love.event.quit()
            end
        }
    }
}
