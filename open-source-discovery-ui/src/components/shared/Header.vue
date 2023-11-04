<template>
  <header class="bg-white">
    <nav
      class="mx-auto flex max-w-7xl items-center justify-between"
      aria-label="Global"
    >
      <div class="flex lg:flex-1">
        <a href="/" class="">
          <img class="h-24 p-0 m-0" src="/images/nasachallenge.png" alt="" />
        </a>
      </div>

      <div class="w-3/5">
        <label for="search" class="text-sm font-medium text-gray-900 sr-only"
          >Search</label
        >
        <div class="relative">
          <div
            class="absolute inset-y-0 left-0 flex items-center pl-3 pointer-events-none"
          >
            <svg
              class="w-4 h-4 text-gray-500"
              aria-hidden="true"
              xmlns="http://www.w3.org/2000/svg"
              fill="none"
              viewBox="0 0 20 20"
            >
              <path
                stroke="currentColor"
                stroke-linecap="round"
                stroke-linejoin="round"
                stroke-width="2"
                d="m19 19-4-4m0-7A7 7 0 1 1 1 8a7 7 0 0 1 14 0Z"
              />
            </svg>
          </div>
          <input
            type="search"
            id="search"
            class="block w-full p-4 pl-10 text-sm text-gray-900 border border-gray-300 rounded-lg bg-gray-50 focus:ring-blue-500 focus:border-blue-500 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
            placeholder="Search..."
            required
          />
          <button
            type="submit"
            class="text-white absolute right-2.5 bottom-2.5 bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm px-4 py-2"
          >
            Search
          </button>
        </div>
      </div>

      <div class="hidden lg:flex lg:flex-1 lg:justify-end">
        <template v-if="logged">
          <div>
            <img src="" alt="" />
            <p class="text-sm font-semibold leading-6 text-gray-900">
              <a href="/profile"> Seja bem vindo Gustavo! </a>
            </p>
          </div>
          <a
            v-on:click="logout()"
            href="/"
            class="ml-3 text-sm font-semibold leading-6 text-red-900"
            >Logout</a
          >
        </template>
        <template v-else>
          <a
            href="/login"
            :aria-disabled="true"
            class="text-sm font-semibold leading-6 text-gray-500"
            >Log in <span aria-hidden="true">&rarr;</span></a
          >
        </template>
      </div>
    </nav>
    <hr />
  </header>
</template>

<script>
export default {
  data() {
    return {
      logged: false,
      name: "",
    };
  },
  methods: {
    logout() {
      localStorage.clear();
      this.$router.push("/");
    },
  },
  created() {
    let id = localStorage.getItem("id");
    if (id != null) {
      this.logged = true;
      this.name = localStorage.getItem("name");
    }
  },
};
</script>
