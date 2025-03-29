import os

def list_files(startpath, output_file):
    with open(output_file, 'w', encoding='utf-8') as f:
        for root, dirs, files in os.walk(startpath, topdown=True):
            # 忽略以点开头的目录
            dirs[:] = [d for d in dirs if not d.startswith('.')]
            
            # 计算当前目录的缩进级别
            level = root.replace(startpath, '').count(os.sep)
            indent = ' ' * 4 * level
            # 写入当前目录名（忽略以点开头的目录）
            if not os.path.basename(root).startswith('.'):
                f.write(f'{indent}{os.path.basename(root)}/\n')
            
            # 写入当前目录下的文件（忽略以点开头的文件）
            sub_indent = ' ' * 4 * (level + 1)
            for file in files:
                if not file.startswith('.'):
                    f.write(f'{sub_indent}{file}\n')

if __name__ == "__main__":
    # 设置要遍历的目录路径
    startpath = input("请输入要遍历的目录路径: ")
    # 设置输出文件路径
    output_file = input("请输入输出文件的路径: ")
    # 调用函数生成目录结构
    list_files(startpath, output_file)
    print(f"目录结构已成功写入到 {output_file}")