### 需求分析

#### UI界面
包括排行榜界面，每一个Item，排行榜动态生成，之后每次点击 Close 按钮关闭设置 setactive 为 false。点击每一个item 展示相关信息。

排行榜页面：滑动框，滑动框中设置item，title，倒计时，关闭按钮，需要实现元素复用。
item：包括 排名、头像、id、段位标识、奖杯。
展示页面：包括 id、段位。

#### 脚本类
StoreDialog：排行榜页面，实现item实例化 和 倒计时协程。

ItemConfig：通过 json 文件读取数据。


RankDialog：排行榜，列表初始化，列表复用。

ItemDialog：item 页面，加载数据类实现 item，实现对 ui 的控制。

HomePage：主界面，开关排行榜。

TipsDialog：提示框，显示玩家信息。

TitleDialog：标题信息。
