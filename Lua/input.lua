input = {}

-- NOTE: use scancode instead of raw key?
function love.keypressed(key, scancode, isrepeat)
    if not isrepeat then
        for _, shortcut in pairs(settings.shortcuts) do
            if key == shortcut.key then
                shortcut.func()
            end
        end

        for action, binds in pairs(settings.keys) do
            for _, bind in pairs(binds) do
                if key == bind then
                    input[action] = true
                end
            end
        end
    end
end

function love.keyreleased(key, scancode)
    for action, binds in pairs(settings.keys) do
        for _, bind in pairs(binds) do
            if key == bind then
                input[action] = false
            end
        end
    end
end

function love.gamepadpressed(gamepad, button)
    for action, bind in pairs(settings.gamepad) do
        if button == bind then
            input[action] = true
        end
    end
end

function love.gamepadreleased(gamepad, button)
    for action, bind in pairs(settings.gamepad) do
        if button == bind then
            input[action] = false
        end
    end
end

function love.gamepadaxis(joystick, axis, value)
    -- local deadzone = 0.1
end
