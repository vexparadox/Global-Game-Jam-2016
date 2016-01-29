util = {
    timerQueue = {}
}

-- calculate distance between two points in 2d
function util.dist(x1, y1, x2, y2)
    return ((x2-x1)^2+(y2-y1)^2)^0.5
end

-- calculate distance between two points in 3d
function util.dist3D(x1, y1, z1, x2, y2, z2)
    return ((x2-x1)^2+(y2-y1)^2+(z2-z1)^2)^0.5
end

-- calculate angle between two points
function util.angle(x1, y1, x2, y2)
    return math.atan2(y2-y1, x2-x1)
end

-- round number to given decimal places
function util.round(n, d)
    d = 10^(d or 0) return math.floor(n*d+.5)/d
end

-- clamp number between two values
function util.clamp(low, n, high)
    return math.min(math.max(low, n), high)
end

-- scale a value (using its range) to a given range
function util.map(value, vLow, vHigh, low, high)
    return low + (high - low) * (value - vLow) / (vHigh - vLow)
end

-- check if a point is within rectangle bounds
function util.pointInRect(x, y, rX, rY, rW, rH)
    return x < rX + rW and
           y < rY + rH and
           rX < x and
           rY < y
end

-- call a function after a given time
function util.timer(f, time)
    local t = love.timer.getTime()
    table.insert(util.timerQueue, {
        f = f,
        t = t + time
    })
end

-- repeat a function call at a given interval (waits for first call)
function util.interval(f, interval, n)
    local t = love.timer.getTime()
    table.insert(util.timerQueue, {
        f = f,
        t = t + interval,
        i = interval,
        n = n,
        tick = 0
    })
end

-- handle the timer queue to call timed functions
function util.manageTimer()
    for i, timer in pairs(util.timerQueue) do
        local t = love.timer.getTime()
        if timer.i and t > timer.t then
            if timer.n then
                if timer.tick < timer.n then
                    timer.f()
                    timer.t = t + timer.i
                    timer.tick = timer.tick + 1
                else
                    table.remove(util.timerQueue, i)
                end
            else
                timer.f()
                    timer.t = t + timer.i
            end
        elseif timer.t and t > timer.t then
            timer.f()
            table.remove(util.timerQueue, i)
        end
    end

end
