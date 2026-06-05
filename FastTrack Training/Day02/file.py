with open("names.txt", encoding="utf-8") as f:
    names = []
    seen = set()
    for name in f.read().split(","):
        name = name.strip()
        key = name.lower()
        if name and key not in seen:
            seen.add(key)
            names.append(name)

for name in names:
    print(name)
