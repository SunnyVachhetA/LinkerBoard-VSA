// localStorageUtil.ts

class LocalStorageUtil {
  // Set an item in localStorage
  static setItem<T>(key: string, value: T): void {
    try {
      const serializedValue = JSON.stringify(value);
      localStorage.setItem(key, serializedValue);
    } catch (error) {
      console.error(`Error setting item in localStorage: ${error}`);
    }
  }

  // Get an item from localStorage
  static getItem<T>(key: string): T | null {
    try {
      const serializedValue = localStorage.getItem(key);
      if (serializedValue === null) {
        return null;
      }
      return JSON.parse(serializedValue) as T;
    } catch (error) {
      console.error(`Error getting item from localStorage: ${error}`);
      return null;
    }
  }

  // Remove an item from localStorage
  static removeItem(key: string): void {
    try {
      localStorage.removeItem(key);
    } catch (error) {
      console.error(`Error removing item from localStorage: ${error}`);
    }
  }
}

export default LocalStorageUtil;
