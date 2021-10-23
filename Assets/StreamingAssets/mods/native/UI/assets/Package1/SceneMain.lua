Button = {}
function Button:new (o)
    o = o or {}
    setmetatable(o, self)
    self.__index = self
    return o
end

Text = {}
function Text:new (o)
    o = o or {}
    setmetatable(o, self)
    self.__index = self
    return o
end

SceneMain={}

SceneMain.UI_DEFINE = {}

SceneMain.UI_DEFINE['Player'] = Button:new()
SceneMain.UI_DEFINE['Player'].OnClick = function ()
    print("SceneMain.UI_DEFINE['Player'].OnClick")
    --SceneMain.UI_DEFINE['Player/Title'].SetValue('123')
end

SceneMain.UI_DEFINE['Player/Title'] = Text:new()
SceneMain.UI_DEFINE['Player/Title'].OnRefresh = function ()
    return '123'
end