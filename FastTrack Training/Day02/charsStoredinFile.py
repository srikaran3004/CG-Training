import sys


def count_chars(path):
	try:
		with open(path, 'r', encoding='utf-8') as f:
			data = f.read()
		return len(data)
	except FileNotFoundError:
		print(f"File not found: {path}")
		return None
	except Exception as e:
		print(f"Error: {e}")
		return None


def main():
	if len(sys.argv) > 1:
		path = sys.argv[1]
	else:
		path = input('Enter file path: ').strip()
	result = count_chars(path)
	if result is not None:
		print(result)


if __name__ == '__main__':
	main()

