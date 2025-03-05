import apiClient from "@/utils/axiosInstance";

export async function loginUser(email: string, password: string) {
    try {
        const response = await apiClient.post("/auth/login", { email, password });
        return response.data;
    } catch (error) {
        console.error("Chyba při přihlášení:", error);
        throw error;
    }
}

export async function registerUser(email: string, password: string) {
    try {
        const response = await apiClient.post("/auth/register", { email, password });
        return response.data;
    } catch (error) {
        console.error("Chyba při registraci:", error);
        throw error;
    }
}
