## 📋 常用指令汇总

| 命令                       | 作用说明                             |
| ------------------------ | -------------------------------- |
| `uv init <project>`      | 直接创建一个带有git readme python虚拟环境的项目 |
| `uv run main.py`         | 运行一个python文件                     |
| `uv venv`                | 创建虚拟环境并生成 `pyproject.toml`       |
| `uv pip install <pkg>`   | 安装包到虚拟环境中                        |
| `uv pip uninstall <pkg>` | 卸载包                              |
| `uv pip freeze`          | 显示当前环境下安装的所有依赖版本                 |
| `uv venv exec <cmd>`     | 在虚拟环境中执行某个命令                     |
| `uv pip list`            | 列出当前环境中的包和版本                     |
| `uv sync`                | 同步环境（根据锁文件安装）                    |
| `uv pip check`           | 检查依赖包之间是否存在冲突                    |

---

## ✅ uv 是什么？



`uv` 是一个“**下一代的 Python 包管理器和执行工具**”，可以：

- 创建和管理虚拟环境（类似 `virtualenv`）
    
- 安装依赖（类似 `pip`）
    
- 管理项目（类似 `pip-tools` / `poetry`）
    
- 超高速：比 pip 安装快数倍
    
- 零依赖，跨平台



## 🧩 安装 `uv`

你可以用下面的方式安装 `uv`：

```bash
curl -Ls https://astral.sh/uv/install.sh | bash
```

或者使用 `pipx`（推荐用于独立命令行工具）：

```bash
pipx install uv
```

安装完后，你可以通过 `uv --version` 验证是否成功。


## ✅ 推荐安装 `uv` 的方法（在中国大陆可行）：

### 方法一：使用 pipx + 清华源

```bash
sudo apt install pipx
pipx ensurepath
pipx install uv --pip-args='-i https://pypi.tuna.tsinghua.edu.cn/simple'
```

然后验证：

```bash
uv --version
```

---

## 🚀 使用 `uv` 入门（替代 pip + virtualenv）

### 1. 初始化项目（创建虚拟环境 ）

```bash
uv init projectName
```

直接创建一个带有git readme python虚拟环境的项目。但是在我的环境下就创建了git readme 虚拟环境还需要运行 `uv venv` 进行初始化

---

### 2. 安装依赖包

```bash
uv pip install requests
```

注意：`uv` 并不是重写了 `pip` 的命令，而是直接调用其自己的安装器，所以用 `uv pip install` 是推荐方式。

国内用户在安装依赖包的时候可能会出现网络速度慢的问题，可以通过配置镜像源来解决


### .python-version
指定python版本
### pyproject.toml
项目的说明书

#### 如何给uv配置镜像源
在项目的 `pyproject.toml` 文件中添加以下内容：
``` toml
[tool.uv]
index-url = "https://mirrors.aliyun.com/pypi/simple"
# 或者使用清华源
[tool.uv]
index-url = "https://pypi.tuna.tsinghua.edu.cn/simple"
```
配置好安装就快多了

---

### 3. 激活虚拟环境

```bash
source .venv/bin/activate  # Linux/macOS
.venv\Scripts\activate     # Windows
```

也可以用 `uv venv exec` 执行某个命令：

```bash
uv venv exec python your_script.py
```

---

### 4. 锁定依赖

和 `pip freeze` 类似，但更现代：

```bash
uv pip freeze > requirements.txt
```

或者用 `uv pip compile`（计划功能，类似 `pip-tools`）

---


## 📌 uv vs pip/poetry/pipenv 对比简表

|功能/工具|pip|poetry|pipenv|uv|
|---|---|---|---|---|
|速度|慢|中|慢|🚀 快速|
|虚拟环境管理|无|内建|内建|✅ 内建|
|安装依赖|✅|✅|✅|✅ 超快|
|自动锁文件生成|❌|✅|✅|✅|
|CLI 体验|简单|统一|略复杂|🚀 简洁统一|
|编写语言|Python|Python|Python|Rust 编写|

---

## 拓展玩法

### 临时脚本命令


## 📚 学习资料推荐

- 官方主页：[https://astral.sh](https://astral.sh/)
    
- GitHub 仓库：[https://github.com/astral-sh/uv](https://github.com/astral-sh/uv)
    
- 中文社区/教程：目前较少，可以关注 B 站、知乎等平台的 Astral/uv 相关内容
	- 【【uv】Python迄今最好的项目管理+环境管理工具（吧？）】 https://www.bilibili.com/video/BV1ajJ7zPEa5/?share_source=copy_web&vd_source=445f9fe806d1b40f2620f76957091c99
    