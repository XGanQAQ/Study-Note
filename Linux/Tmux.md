你可以使用 **Tmux** 来保持终端会话，即使你关闭了终端窗口，程序仍然在后台继续运行。这里是如何操作的：

### 1. 启动一个新的 Tmux 会话
在终端中输入以下命令来启动一个新的 Tmux 会话：

```bash
tmux new-session -s mysession
```

这将启动一个名为 `mysession` 的新会话。

### 2. 在 Tmux 中运行程序
在 Tmux 会话中，你可以正常运行任何程序。例如，运行一个 Python 脚本：

```bash
python myscript.py
```

或者运行其他程序。

### 3. 分离（Detach）会话
当你想要将程序继续在后台运行时，可以按下 `Ctrl + B` 后松开，再按 `D`，这会让你“分离”出当前会话，程序将继续在后台运行。

### 4. 重新连接（Attach）会话
如果你想重新连接到先前的会话，可以使用以下命令：

```bash
tmux attach -t mysession
```

这将让你回到 `mysession` 会话，继续查看和交互。

### 5. 查看当前会话
你可以使用以下命令列出当前的 Tmux 会话：

```bash
tmux ls
```

### 6. 结束会话
如果你完成了工作并想结束会话，可以使用 `exit` 命令或者按 `Ctrl + D`。

使用 Tmux 可以非常方便地管理和保持你的终端会话，特别是当你需要长时间运行一些程序时，它能防止断开连接后丢失进程。